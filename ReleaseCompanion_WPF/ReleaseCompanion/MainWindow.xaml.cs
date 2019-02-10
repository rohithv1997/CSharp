using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Security.Principal;
using System.Windows.Controls;
using System.Text;
using System.Windows.Shell;

namespace ReleaseCompanion
{
    public partial class MainWindow : System.Windows.Window
    {
        #region Variables

        static List<Parameters> _parameters;
        static bool _isWindowsServiceRequired;
        static string _lessorPortalReleasePath;
        static string _brokerPortalReleasePath;

        static string[] _foldersToCopy;
        static string[] _fileExtensionsToExclude;

        static bool _clearOldBackups;
        static int _numberOfBackupsToRetain;

        static List<AppSetting> targetAppSettings;
        static List<AppSetting> modifiedAppSettings;
        static List<AppSetting> commonModifiedAppSettings;

        static string _AppPath, _AppURL;

        static bool _cleanUpFiles;
        static string[] _fileExtensionsToClean;

        static string _logFilePath;
        static string _logFileName;

        static string _excelPath;

        static StringBuilder _environments = new StringBuilder();

        static bool _isAppSettingConvertorRequired;

        static string[] _foldersForWindowsServiceBackup;
        static string _filesForWindowsService;

        static LogFileHelper logHelper;

        static double progress = 0;

        #endregion

        public MainWindow()
        {

            InitializeComponent();
            var user = WindowsIdentity.GetCurrent();
            userName.Content = user.Name;
            GetAppConfigValues();
            _logFileName = _logFilePath + "Release_Log-" + DateTime.Now.ToString("yyyy-MM-ddTHHmmss") + ".txt";
            if (!Directory.Exists(_logFilePath))
                Directory.CreateDirectory(_logFilePath);
            logHelper = new LogFileHelper(_logFileName);
            logHelper.AppendToLogFile("Release Helper");
            Application.Current.Exit += Application_Exit;
            try
            {
                _parameters = ExcelReader.FetchDetailsFromExcel(_excelPath);
                FillEnvironmentList();
                environments_grid.Columns[0].IsReadOnly = true;
                environments_grid.Columns[1].IsReadOnly = true;
                environments_grid.Columns[4].IsReadOnly = true;
                environments_grid.Columns[5].IsReadOnly = true;
                _isAppSettingConvertorRequired = false;
                commonModifiedAppSettings = new List<AppSetting>();
                appSettings_grid.Visibility = Visibility.Hidden;
                appSettings_grid.ItemsSource = new ObservableCollection<AppSetting>();
                sql_environments_grid.Columns[0].IsReadOnly = true;
                sql_environments_grid.Columns[1].IsReadOnly = true;
            }
            catch (Exception e)
            {
                logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Error: " + e.Message + (e.InnerException?.Message) ?? string.Empty);
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Release Companion Closed.");
        }

        public void FillEnvironmentList()
        {
            ObservableCollection<GridParam> dataSource = new ObservableCollection<GridParam>();
            ObservableCollection<GridParam> sqlDataSource = new ObservableCollection<GridParam>();
            foreach (var param in _parameters)
            {
                var gridParam = new GridParam();
                gridParam.SerialNumber = param.SerialNumber;
                gridParam.Name = param.NickName;
                gridParam.Backup = false;
                gridParam.Release = false;
                gridParam.IsLessorPortal = (param.EnvironmentType == EnvironmentType.LessorPortal);
                if (param.ReleaseType == ReleaseType.BackupandRelease)
                {
                    gridParam.Backup = true;
                    gridParam.Release = true;
                }
                else if (param.ReleaseType == ReleaseType.BackupOnly)
                {
                    gridParam.Backup = true;
                    gridParam.Release = false;
                }
                else if (param.ReleaseType == ReleaseType.ReleaseOnly)
                {
                    gridParam.Backup = false;
                    gridParam.Release = true;
                }
                dataSource.Add(gridParam);
                if (gridParam.IsLessorPortal)
                    sqlDataSource.Add(gridParam);
            }
            environments_grid.ItemsSource = dataSource;
            sql_environments_grid.ItemsSource = sqlDataSource;
        }

        private void GetAppConfigValues()
        {
            _foldersToCopy = ReadAppSettings("FoldersToCopyForBackup", string.Empty, Convert.ToString).Split(',');
            _fileExtensionsToExclude = ReadAppSettings("FileExtensionsToExclude", string.Empty, Convert.ToString).Split(',');
            _brokerPortalReleasePath = ReadAppSettings("BrokerPortalPublishPath", string.Empty, Convert.ToString);
            _lessorPortalReleasePath = ReadAppSettings("LessorPortalPublishPath", string.Empty, Convert.ToString);
            _isWindowsServiceRequired = ReadAppSettings("IsWindowsServiceRequired", false, Convert.ToBoolean);
            _clearOldBackups = ReadAppSettings("ClearOldBackups", false, Convert.ToBoolean);
            _numberOfBackupsToRetain = ReadAppSettings("NumberOfOldBackupsToRetain", 3, Convert.ToInt32);
            _cleanUpFiles = ReadAppSettings("CleanUpRequired", false, Convert.ToBoolean);
            _fileExtensionsToClean = ReadAppSettings("FileExtensionsToCleanUp", string.Empty, Convert.ToString).Split(',');
            _logFilePath = ReadAppSettings("LogFilePath", string.Empty, Convert.ToString);
            _excelPath = ReadAppSettings("ExcelPath", string.Empty, Convert.ToString);
            _filesForWindowsService = ReadAppSettings("FilesForWindowsServices", string.Empty, Convert.ToString);
            _foldersForWindowsServiceBackup = ReadAppSettings("FoldersToCopyForWindowsServiceBackup", string.Empty, Convert.ToString).Split(',');
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateParameters();
                if (_parameters.Any(x => x.ReleaseType != ReleaseType.None))
                {
                    Release_btn.Visibility = Visibility.Hidden;
                    progressBar.Visibility = Visibility.Visible;
                    progressBar.Minimum = 0;
                    environments_grid.IsEnabled = false;
                    appSettingRequired.IsEnabled = false;
                    appSettings_grid.IsEnabled = false;
                    var max = _parameters.Where(x => x.ReleaseType == ReleaseType.BackupandRelease && x.EnvironmentType == EnvironmentType.LessorPortal).Count() * 3
                            + _parameters.Where(x => x.ReleaseType == ReleaseType.BackupandRelease && x.EnvironmentType == EnvironmentType.BrokerPortal).Count() * 2
                            + _parameters.Where(x => x.ReleaseType == ReleaseType.ReleaseOnly && x.EnvironmentType == EnvironmentType.LessorPortal).Count() * 2
                            + _parameters.Where(x => x.ReleaseType == ReleaseType.ReleaseOnly && x.EnvironmentType == EnvironmentType.BrokerPortal).Count()
                            + _parameters.Where(x => x.ReleaseType == ReleaseType.BackupOnly).Count() + 1;
                    progressBar.Maximum = max;
                    progress = (double)1 / max;
                    TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
                    TaskbarItemInfo.ProgressValue = 0;
                    progressLabel.Visibility = Visibility.Visible;
                    progressLabel.Foreground = Brushes.Green;
                    progressLabel.Text = "Starting Release";
                    progressLabel.Foreground = Brushes.Black;
                    userName.MouseDoubleClick -= new System.Windows.Input.MouseButtonEventHandler(userName_MouseDoubleClick);
                    DoRelease();
                }
                else
                {
                    MessageBox.Show(this, "No environment selected for Release.", "Information");
                }
            }
            catch (Exception ex)
            {
                progressLabel.Foreground = Brushes.Red;
                progressLabel.Text += "Error: " + ex.Message;
                progressLabel.Foreground = Brushes.Black;
                logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Error: " + ex.Message + " Inner Exception: " + (ex.InnerException?.Message) ?? string.Empty);
            }
        }

        private void appSettingRequired_Checked(object sender, RoutedEventArgs e)
        {
            _isAppSettingConvertorRequired = appSettingRequired.IsChecked.Value;
            if (_isAppSettingConvertorRequired)
            {
                appSettings_grid.Visibility = Visibility.Visible;

            }
            else
            {
                appSettings_grid.Visibility = Visibility.Hidden;
                commonModifiedAppSettings = new List<AppSetting>();
                appSettings_grid.ItemsSource = new ObservableCollection<AppSetting>();
            }
        }

        #region User Impersonation

        private void Window_Activated(object sender, EventArgs e)
        {
            var user = WindowsIdentity.GetCurrent();
            userName.Content = user.Name;
        }

        private void userName_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var obj = new UserLogin();
            obj.Show();
            Hide();
        }

        #endregion

        private void CompleteRelease(object sender, RoutedEventArgs e)
        {
            environments_grid.CommitEdit();
            GridParam model = (sender as Button).DataContext as GridParam;
            foreach (GridParam item in environments_grid.ItemsSource)
            {
                if (item.SerialNumber == model.SerialNumber)
                {
                    item.Backup = true;
                    item.Release = true;
                    item.ScriptRequired = true;
                }
            }
            environments_grid.Items.Refresh();
            foreach (GridParam item in sql_environments_grid.ItemsSource)
            {
                if (item.SerialNumber == model.SerialNumber)
                    item.ScriptRequired = true;
            }
            sql_environments_grid.Items.Refresh();
        }

        #region SQL Execute

        private void GetFileForBrowse(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".sql";
            dlg.Filter = "SQL Files (*.sql)|*.sql;";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string filePath = dlg.FileName;
                UpdateParametersForSQL(filePath);
            }
        }

        public void UpdateParametersForSQL(string filePath)
        {
            sql_environments_grid.CommitEdit();
            foreach (GridParam item in sql_environments_grid.ItemsSource)
            {
                if (item.ScriptRequired)
                {
                    item.FilePath = filePath;
                    var param = _parameters.Where(x => x.SerialNumber == item.SerialNumber).FirstOrDefault();
                    param.FilePath = filePath;
                }
            }
            sql_environments_grid.Items.Refresh();
        }

        private void getfiledetail(object sender, RoutedEventArgs e)
        {
            GridParam model = (sender as Button).DataContext as GridParam;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".sql";
            dlg.Filter = "SQL Files (*.sql)|*.sql;";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                sql_environments_grid.CommitEdit();
                string filePath = dlg.FileName;
                foreach (GridParam item in sql_environments_grid.ItemsSource)
                {
                    if (item.SerialNumber == model.SerialNumber)
                    {
                        item.FilePath = filePath;
                        var param = _parameters.Where(x => x.SerialNumber == item.SerialNumber).FirstOrDefault();
                        param.FilePath = filePath;
                    }
                }
            }
            sql_environments_grid.Items.Refresh();
        }

        private void ClearFile(object sender, RoutedEventArgs e)
        {
            sql_environments_grid.CommitEdit();
            GridParam model = (sender as Button).DataContext as GridParam;
            foreach (GridParam item in sql_environments_grid.ItemsSource)
            {
                if (item.SerialNumber == model.SerialNumber)
                {
                    item.FilePath = string.Empty;
                    var param = _parameters.Where(x => x.SerialNumber == item.SerialNumber).FirstOrDefault();
                    param.FilePath = string.Empty;
                }
            }
            sql_environments_grid.Items.Refresh();
        }

        private void ClearRelease(object sender, RoutedEventArgs e)
        {
            environments_grid.CommitEdit();
            GridParam model = (sender as Button).DataContext as GridParam;
            foreach (GridParam item in environments_grid.ItemsSource)
            {
                if (item.SerialNumber == model.SerialNumber)
                {
                    item.Backup = false;
                    item.Release = false;
                    item.ScriptRequired = false;
                }
            }
            environments_grid.Items.Refresh();
            foreach (GridParam item in sql_environments_grid.ItemsSource)
            {
                if (item.SerialNumber == model.SerialNumber)
                {
                    item.ScriptRequired = false;
                    item.FilePath = string.Empty;
                    var param = _parameters.Where(x => x.SerialNumber == item.SerialNumber).FirstOrDefault();
                    param.FilePath = string.Empty;
                }
            }
            sql_environments_grid.Items.Refresh();
        }

        private void sql_Execute_Click(object sender, RoutedEventArgs e)
        {
            var parameters = _parameters.Where(x => x.FilePath != string.Empty && x.FilePath != null).Select(x => x);
            foreach (var param in parameters)
            {
                if (param.DBServerName == string.Empty || param.DBServerName == null || param.DBName == string.Empty || param.DBName == null)
                {
                    var result = MessageBox.Show(this, param.NickName + " environment doesn't have a DB Server name or DB name.", "Error", MessageBoxButton.OK);
                    logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Error: " + param.NickName + " environment doesn't have a DB Server name or DB name.");
                }

                else
                {
                    logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Info: " + param.NickName + " script execution started.");
                    sqlprogressLabel.Text = "Script Executing in " + param.NickName;
                    sqlprogressLabel.Refresh();
                    string error;
                    bool success = ScriptExecutor.ExecuteScript(param.DBServerName, param.DBName, param.FilePath, out error);
                    if (success)
                    {
                        sqlprogressLabel.Text = "Script Execution has been completed in " + param.NickName;
                        sqlprogressLabel.Refresh();
                    }
                    else
                    {
                        logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Error: " + error);
                        var res = MessageBox.Show(this, param.NickName + " Exception occured: " + error, "Error", MessageBoxButton.OK);
                    }
                }
            }
        }

        #endregion

        #region Common Methods

        private void openApplications(string[] urls)
        {
            foreach (var url in urls)
            {
                Process.Start(url);
            }
        }

        private void FWRelease(object sender, RoutedEventArgs e)
        {
            ApplyFWRelease();
        }

        private void ApplyFWRelease()
        {
            throw new NotImplementedException();
        }

        private T ReadAppSettings<T>(string key, T defaultValue, Func<string, T> converter)
        {
            var setting = ConfigurationManager.AppSettings[key];
            if (setting != null)
                return converter(setting);
            else
            {
                progressLabel.Foreground = Brushes.Red;
                progressLabel.Text += "\nApp Setting key: " + key + " not found.";
                progressLabel.Foreground = Brushes.Black;
                return defaultValue;
            }
        }

        private bool ExecuteBatchFile(string location)
        {
            try
            {
                progressBar.Value++;
                TaskbarItemInfo.ProgressValue = progressBar.Value * progress;
                progressBar.Refresh();
                string error = string.Empty;
                logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Executing Batch File: " + location);
                var processInfo = new ProcessStartInfo(location);
                processInfo.Verb = "runas";
                var process = Process.Start(processInfo);
                process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                     error = e.Data;
                if (error != string.Empty)
                {
                    progressLabel.Foreground = Brushes.Red;
                    progressLabel.Text += error;
                    logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Error: " + error);
                    progressLabel.Foreground = Brushes.Black;
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion
    }
}
