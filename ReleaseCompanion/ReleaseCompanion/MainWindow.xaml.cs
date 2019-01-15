using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml;
using System.Windows.Media;
using System.Windows.Threading;
using System.Security.Principal;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Shell;

namespace ReleaseCompanion
{
    public partial class MainWindow : System.Windows.Window
    {
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

        static string _environments;

        static bool _isAppSettingConvertorRequired;

        static double progress = 0;

        public MainWindow()
        {
            InitializeComponent();
            var user = WindowsIdentity.GetCurrent();
            userName.Content = user.Name;
            GetAppConfigValues();
            _logFileName = _logFilePath + "Release_Log-" + DateTime.Now.ToString("yyyy-MM-ddTHHmmss") + ".txt";
            AppendToLogFile("Release Helper");
            try
            {
                FetchDetailsFromExcel();
                FillEnvironmentList();
                environments_grid.Columns[0].IsReadOnly = true;
                environments_grid.Columns[1].IsReadOnly = true;
                _isAppSettingConvertorRequired = false;
                commonModifiedAppSettings = new List<AppSetting>();
                appSettings_grid.Visibility = Visibility.Hidden;
                appSettings_grid.ItemsSource = new ObservableCollection<AppSetting>();
            }
            catch(Exception e)
            {
                AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Error: " + e.Message + (e.InnerException?.Message) ?? string.Empty);
            }
        }

        public void FillEnvironmentList()
        {
            ObservableCollection<GridParam> dataSource = new ObservableCollection<GridParam>();
            foreach (var param in _parameters)
            {
                var gridParam = new GridParam();
                gridParam.SerialNumber = param.SerialNumber;
                gridParam.Name = param.NickName;
                gridParam.Backup = false;
                gridParam.Release = false;
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
            }
            environments_grid.ItemsSource = dataSource;
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

        private EnvironmentType FetchEnvironmentType(string param)
        {
            if (param == "Broker Portal")
                return EnvironmentType.BrokerPortal;
            return EnvironmentType.LessorPortal;
        }

        private ReleaseType FetchReleaseType(string param)
        {
            if (param == "Release only")
                return ReleaseType.ReleaseOnly;
            else if (param == "Backup only")
                return ReleaseType.BackupOnly;
            else if (param == "Backup and Release")
                return ReleaseType.BackupandRelease;
            return ReleaseType.None;
        }

        public void FetchDetailsFromExcel()
        {
            _parameters = new List<Parameters>();
            string fullPathToExcel = ConfigurationManager.AppSettings["ExcelPath"];
            fullPathToExcel = AppDomain.CurrentDomain.BaseDirectory + fullPathToExcel;
            DataTable dt = GetDataTable(fullPathToExcel, "Paths");

            foreach (DataRow dr in dt.Rows)
            {
                var param = new Parameters();
                int serialNumber = 0;
                if (int.TryParse(dr[0].ToString(), out serialNumber))
                {
                    param.SerialNumber = Convert.ToInt32(dr[0]);
                    param.NickName = Convert.ToString(dr[1]);
                    param.EnvironmentType = FetchEnvironmentType(Convert.ToString(dr[2]));
                    param.ServerPath = Convert.ToString(dr[3]);
                    param.AppURL = Convert.ToString(dr[4]);
                    param.BackupPath = Convert.ToString(dr[5]);
                    var start = Convert.ToString(dr[6]);
                    param.BatchFileStart = start != "" ? start : "Invalid";
                    var stop = Convert.ToString(dr[7]);
                    param.BatchFileStop = stop != "" ? stop : "Invalid";

                    _parameters.Add(param);
                }
                else
                {
                    break;
                }
            }
        }

        public void DoRelease()
        {
            var lessorPortals = _parameters.Where(x => (x.ReleaseType == ReleaseType.ReleaseOnly || x.ReleaseType == ReleaseType.BackupandRelease) && x.EnvironmentType == EnvironmentType.LessorPortal).Select(x => x.NickName).ToList();
            if(lessorPortals.Any())
            {
                _environments = lessorPortals.ToCSV();
            }
            else
            {
                var brokerPortals = _parameters.Where(x => (x.ReleaseType == ReleaseType.ReleaseOnly || x.ReleaseType == ReleaseType.BackupandRelease) && x.EnvironmentType == EnvironmentType.BrokerPortal).Select(x => x.NickName).ToList();
                _environments = brokerPortals.ToCSV();
            }
            Clipboard.SetText("Team," + Environment.NewLine + "Please refrain from using " + _environments + " environments for a while as we are doing a release." + Environment.NewLine + Environment.NewLine + "Thanks!");
            TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Paused;
            var rslt = MessageBox.Show(this, "Release message copied to Clipboard. Please send it to the Team.", "Information", MessageBoxButton.OK);
            TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
            var _batchFileParameters = _parameters.Where(x => x.ReleaseType == ReleaseType.ReleaseOnly || x.ReleaseType == ReleaseType.BackupandRelease).ToList();

            List<int> invalidBatchFileEnvironments = new List<int>();

            foreach (var parameter in _batchFileParameters)
            {
                if (parameter.BatchFileStop != "Invalid")
                {
                    if (!ExecuteBatchFile(parameter.BatchFileStop))
                        invalidBatchFileEnvironments.Add(parameter.SerialNumber);
                }
            }

            if (invalidBatchFileEnvironments.Any())
            {
                TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Error;
                var result = MessageBox.Show("Windows service not stopped in the following environments " + invalidBatchFileEnvironments.ToCSV() + "\n Do you wish to continue?", "Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No)
                {
                    progressLabel.Foreground = Brushes.Red;
                    progressLabel.Text = "Release Aborted!!!";
                    TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
                    return;
                }
                TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
            }

            var _backupParameters = _parameters.Where(x => x.ReleaseType == ReleaseType.BackupOnly || x.ReleaseType == ReleaseType.BackupandRelease).ToList();

            foreach (var parameter in _backupParameters)
            {
                Backup(parameter.ServerPath, parameter.BackupPath, _foldersToCopy);
            }

            if (_isWindowsServiceRequired && _parameters.Any(x => x.EnvironmentType == EnvironmentType.LessorPortal && (x.ReleaseType == ReleaseType.ReleaseOnly || x.ReleaseType == ReleaseType.BackupandRelease)))
            {
                CreateWindowsServices(_lessorPortalReleasePath);
            }

            var _releaseParameters = _parameters.Where(x => x.ReleaseType == ReleaseType.ReleaseOnly || x.ReleaseType == ReleaseType.BackupandRelease).ToList();

            if (_isAppSettingConvertorRequired)
            {
                GetCommonAppSettingChanges();
                foreach (var parameter in _releaseParameters)
                {
                    GetAppSettingsForEnvironment(parameter.SerialNumber);
                    if (parameter.EnvironmentType == EnvironmentType.BrokerPortal)
                    {
                        AppSettingsConverter(_brokerPortalReleasePath, parameter.ServerPath, parameter.AppURL);
                    }
                    else
                    {
                        AppSettingsConverter(_lessorPortalReleasePath, parameter.ServerPath, parameter.AppURL, true);
                    }
                }
            }

            if (_batchFileParameters.Any())
            {
                var message = string.Empty;
                if (_cleanUpFiles)
                    message = "You have selected Clean-up of Old Files, please make sure all necessary files are present in the Publish Folder. Batch Files are run to stop Windows Services. Please verify if they are stopped and click ok to proceed with the release.";
                else
                    message = "Batch Files are run to stop Windows Services. Please verify if they are stopped and click ok to proceed with the release.";
                TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Paused;
                var result = MessageBox.Show(this, message, "Note", MessageBoxButton.OK);
                TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
                AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Starting the release.");
            }

            foreach (var parameter in _releaseParameters)
            {
                if (parameter.EnvironmentType == EnvironmentType.BrokerPortal)
                {
                    Release(_brokerPortalReleasePath, parameter.ServerPath);
                }
                else
                {
                    Release(_lessorPortalReleasePath, parameter.ServerPath);
                }
            }

            foreach (var parameter in _batchFileParameters)
            {
                if (parameter.BatchFileStart != "Invalid")
                    ExecuteBatchFile(parameter.BatchFileStart);
            }

            progressLabel.FontWeight = FontWeights.Bold;
            progressLabel.Foreground = Brushes.Green;
            progressLabel.Text = "Release Completed!!!\nRelease Log: " + _logFileName;
            
            var appURLs = _releaseParameters.Select(x => x.AppURL).ToArray();
            openApplications(appURLs);

            progressBar.Value++;
            TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
            Clipboard.SetText("Team," + Environment.NewLine + "Release has been completed successfully in " + _environments + " environments." + Environment.NewLine + Environment.NewLine + "Thanks for your Co-operation!");
            MessageBox.Show(this, "Release Completed!!!", "Information");
        }

        private bool ExecuteBatchFile(string location)
        {
            try
            {
                progressBar.Value++;
                TaskbarItemInfo.ProgressValue = progressBar.Value * progress;
                progressBar.Refresh();
                string error = string.Empty;
                AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Executing Batch File: " + location);
                var processInfo = new ProcessStartInfo(location);
                processInfo.Verb = "runas";
                var process = Process.Start(processInfo);
                process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                     error = e.Data;
                if (error != string.Empty)
                {
                    progressLabel.Foreground = Brushes.Red;
                    progressLabel.Text += error;
                    AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Error: " + error);
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

        public void UpdateParameters()
        {
            foreach (GridParam item in environments_grid.ItemsSource)
            {
                var param = _parameters.First(x => x.SerialNumber == item.SerialNumber);
                if (item.Release && item.Backup)
                {
                    param.ReleaseType = ReleaseType.BackupandRelease;
                }
                else if (item.Release)
                {
                    param.ReleaseType = ReleaseType.ReleaseOnly;
                }
                else if (item.Backup)
                {
                    param.ReleaseType = ReleaseType.BackupOnly;
                }
                else
                {
                    param.ReleaseType = ReleaseType.None;
                }
            }
        }

        #region Backup

        private void Backup(string sourcePath, string targetPath, string[] foldersToCopy)
        {
            DateTime today = DateTime.Today;
            string currentDateString = today.ToMonthName() + " " + today.Year + "\\" + today.Day + " " + today.ToMonthName() + " " + today.Year;
            var destPath = targetPath;
            targetPath += "\\" + currentDateString;
            progressLabel.Text = "Copying from " + sourcePath + ": ...";
            AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Copying from " + sourcePath);
            progressBar.Value++;
            TaskbarItemInfo.ProgressValue = progressBar.Value * progress;
            progressBar.Refresh();
            try
            {
                string desDir = DirectoryCopy(sourceDirName: sourcePath, destDirName: targetPath, foldersToCopy: foldersToCopy, isRoot: true, fileExtensionsToExclude: new string[] { });
                var bytes = GetDirectorySize(desDir);
                decimal megaBytes = ((decimal)bytes / (1048576));
                progressLabel.Foreground = Brushes.Green;
                AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Backup Successful to \"" + desDir + "\"!!!Total Data Copied: " + megaBytes.ToString("0.00") + " MB");
                progressLabel.Foreground = Brushes.Black;
                if (_clearOldBackups)
                    ClearOldBackups(destPath, _numberOfBackupsToRetain);
            }
            catch (Exception e)
            {
                progressLabel.Foreground = Brushes.Red;
                progressLabel.Text += "\n" + e.Message;
                AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Error: " + e.Message);
                progressLabel.Foreground = Brushes.Black;
            }
        }

        private string DirectoryCopy(string sourceDirName, string destDirName, string[] fileExtensionsToExclude, string[] foldersToCopy = null, bool isRoot = false, bool isRelease = false)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Error: Source directory does not exist or could not be found: " + sourceDirName);
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!isRelease)
                destDirName = CreateDirectory(destDirName);

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                if (!fileExtensionsToExclude.Contains(file.Extension))
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, isRelease);
                }
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                if (isRoot)
                {
                    if (!foldersToCopy.Contains(subdir.Name))
                        continue;
                }
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(sourceDirName: subdir.FullName, destDirName: temppath, isRelease: isRelease, fileExtensionsToExclude: fileExtensionsToExclude);
            }
            return destDirName;
        }

        private string CreateDirectory(string dirName, int i = 0)
        {
            string newDirName = dirName;
            if (i != 0)
                newDirName = dirName + " -" + i.ToString();
            if (Directory.Exists(newDirName))
            {
                return CreateDirectory(dirName, ++i);
            }
            else
            {
                Directory.CreateDirectory(newDirName);
                return newDirName;
            }
        }

        private void ClearOldBackups(string desDir, int numberOfBackupsToKeep)
        {
            DirectoryInfo rootDir = new DirectoryInfo(desDir);
            var monthDirs = rootDir.GetDirectories().OrderBy(x => x.CreationTime);
            List<string> subDirs = new List<string>();
            foreach (var monthDir in monthDirs)
            {
                foreach (var dateDir in monthDir.GetDirectories().OrderBy(x => x.CreationTime))
                    subDirs.Add(dateDir.FullName);
            }
            if (subDirs.Count > numberOfBackupsToKeep)
            {
                var message = string.Empty;
                var directoriesToDelete = subDirs.Take(subDirs.Count - numberOfBackupsToKeep);
                message = "Following backups will be deleted:";
                progressLabel.Foreground = Brushes.Red;
                foreach (var dir in directoriesToDelete)
                {
                    message += "\n" + dir;
                }
                message += "\nThis is permanent and can't be reverted!";
                message = "\nDo you wish to continue?";
                TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Paused;
                var result = MessageBox.Show(message, "Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Backup(s) deleted:- ");
                    int count = 0;
                    try
                    {
                        foreach (var directory in directoriesToDelete)
                        {
                            AppendToLogFile(directory);
                            DeleteDirectory(directory);
                            count++;
                        }
                        // Delete Empty Month Directories
                        foreach (var monthDir in monthDirs)
                        {
                            if (monthDir.GetDirectories().Count() == 0)
                                monthDir.Delete();
                        }
                        progressLabel.Foreground = Brushes.Green;
                        progressLabel.Text = count + " Old Backup(s) deleted successfully!!!";
                        AppendToLogFile(DateTime.Now.ToLongTimeString() + " - " + count + " Old Backup(s) deleted successfully!!!");
                        progressLabel.Foreground = Brushes.Black;
                    }
                    catch (Exception e)
                    {
                        progressLabel.Foreground = Brushes.Red;
                        AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Error: " + e.Message);
                        progressLabel.Text += e.Message;
                        progressLabel.Foreground = Brushes.Black;
                    }
                }
                TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
            }
        }

        public void DeleteDirectory(string targetDir)
        {
            File.SetAttributes(targetDir, FileAttributes.Normal);

            string[] files = Directory.GetFiles(targetDir);
            string[] dirs = Directory.GetDirectories(targetDir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(targetDir, false);
        }

        #endregion

        #region Release

        private void CreateWindowsServices(string publishedLocation)
        {
            string tempPath = Path.Combine(publishedLocation, ConfigurationManager.AppSettings["FoldersToAdd"]);
            DirectoryInfo tempPathDir = new DirectoryInfo(tempPath);


            if (!tempPathDir.Exists)
            {
                Directory.CreateDirectory(tempPath);
            }

            var filesToInclude = ConfigurationManager.AppSettings["FilesForWindowsServices"];
            string[] filesForWindowsServices = filesToInclude.Split(',');

            foreach (var file in filesForWindowsServices)
            {
                SearchFile(publishedLocation, tempPath, file, true);
            }
        }

        private bool SearchFile(string publishedLocation, string targetPath, string fileName, bool IsRoot = false)
        {
            DirectoryInfo dir = new DirectoryInfo(publishedLocation);

            DirectoryInfo[] dirs = dir.GetDirectories();

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                if (fileName == file.Name)
                {
                    var tempPathForWindowsFile = Path.Combine(targetPath, file.Name);
                    file.CopyTo(tempPathForWindowsFile, true);
                    return true;
                }
            }

            foreach (var subDirs in dirs)
            {
                bool success = SearchFile(subDirs.FullName, targetPath, fileName);
                if (success)
                {
                    return true;
                }
            }
            return false;
        }

        private void Release(string sourcePath, string targetPath)
        {
            try
            {
                if (_cleanUpFiles)
                {
                    progressLabel.Text = "Cleaning up old files from " + targetPath;
                    progressLabel.Refresh();
                    AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Cleaning up old files from " + targetPath);
                    CleanUpFiles(targetPath);
                    AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Old files cleaned up from " + targetPath);
                }
                progressLabel.Text = "\nCopying to " + targetPath + ": ...";
                AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Copying from " + sourcePath);
                progressBar.Value++;
                TaskbarItemInfo.ProgressValue = progressBar.Value * progress;
                progressBar.Refresh();
                string desDir = DirectoryCopy(sourceDirName: sourcePath, destDirName: targetPath, fileExtensionsToExclude: _fileExtensionsToExclude, isRelease: true);
                var bytes = GetDirectorySize(sourcePath);
                decimal megaBytes = ((decimal)bytes / (1048576));
                AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Release Successful to \"" + desDir + "\"!!!\nTotal Data Copied: " + megaBytes.ToString("0.00") + " MB");
                progressLabel.Foreground = Brushes.Black;
            }
            catch (Exception e)
            {
                progressLabel.Foreground = Brushes.Red;
                progressLabel.Text += "\n" + e.Message;
                AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Error: " + e.Message);
                progressLabel.Foreground = Brushes.Black;
            }
        }

        private void CleanUpFiles(string path)
        {
            string[] files = Directory.GetFiles(path);
            string[] dirs = Directory.GetDirectories(path);

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (_fileExtensionsToClean.Contains(fileInfo.Extension))
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }
            }

            foreach (string dir in dirs)
            {
                CleanUpFiles(dir);
            }
        }

        #endregion

        #region App Settings

        private void AppSettingsConverter(string sourcePath, string resultPath, string appURL, bool copyToSubFolders = false)
        {
            if (FetchTargetAppSettings(resultPath))
            {
                _AppPath = resultPath;
                _AppURL = appURL;
                var success = CreateResultConfig(sourcePath, resultPath);
                if (success && copyToSubFolders)
                    CopyAppSettingsToChildFolders(resultPath);
            }
        }

        private bool CreateResultConfig(string sourcePath, string resultPath)
        {
            List<string> newKeys = new List<string>();
            XmlDocument resultDoc = new XmlDocument();
            try
            {
                var sourceFile = sourcePath.TrimEnd('\\') + "\\AppSettings.config";
                if (File.Exists(sourceFile))
                    resultDoc.Load(sourcePath.TrimEnd('\\') + "\\AppSettings.config");
                else
                    return false;
            }
            catch (FileNotFoundException e)
            {
                progressLabel.Foreground = Brushes.Red;
                progressLabel.Text += "Error: " + e.Message;
                progressLabel.Foreground = Brushes.Black;
                return false;
            }
            XmlNodeList settings = resultDoc.GetElementsByTagName("add");
            foreach (XmlNode setting in settings)
            {
                string key = setting.Attributes["key"].InnerText;
                var changedValue = modifiedAppSettings.FirstOrDefault(x => x.Key == key);
                if (changedValue != null)
                {
                    string newValue = changedValue.Value;
                    newValue = newValue.Replace("[App_Path]", _AppPath);
                    newValue = newValue.Replace("[App_URL]", _AppURL);
                    setting.Attributes["value"].InnerText = newValue;
                }
                else
                {
                    var targetValue = targetAppSettings.FirstOrDefault(x => x.Key == key);
                    if (targetValue != null)
                    {
                        setting.Attributes["value"].InnerText = targetValue.Value;
                    }
                    else
                    {
                        newKeys.Add(key);
                    }
                }
            }
            resultDoc.Save(resultPath.TrimEnd('\\') + "\\AppSettings.config");
            if (newKeys.Any())
            {
                progressLabel.Text = "Following keys are newly added and don't have a matching value to modify:\n";
                AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Following Key(s) were newly added:-");
                progressLabel.Foreground = Brushes.Cyan;
                foreach (var key in newKeys)
                {
                    progressLabel.Text += "\n" + key;
                    AppendToLogFile(key);
                }
                progressLabel.Foreground = Brushes.Black;
            }
            return true;
        }

        private bool FetchTargetAppSettings(string targetPath)
        {
            targetAppSettings = new List<AppSetting>();
            XmlDocument targetDoc = new XmlDocument();
            try
            {
                var targetFile = targetPath.TrimEnd('\\') + "\\AppSettings.config";
                if (File.Exists(targetFile))
                    targetDoc.Load(targetFile);
            }
            catch (FileNotFoundException e)
            {
                progressLabel.Foreground = Brushes.Red;
                progressLabel.Text += "Error:" + e.Message;
                progressLabel.Foreground = Brushes.Black;
                return false;
            }
            XmlNodeList settings = targetDoc.GetElementsByTagName("add");
            foreach (XmlNode setting in settings)
            {
                string key = setting.Attributes["key"].InnerText;
                string value = setting.Attributes["value"].InnerText;
                targetAppSettings.Add(new AppSetting { Key = key, Value = value });
            }
            return true;
        }

        private void GetCommonAppSettingChanges()
        {
            var appSettings = new List<AppSetting>((ObservableCollection<AppSetting>)appSettings_grid.ItemsSource);
            commonModifiedAppSettings = appSettings.Where(x => x.Key != null && x.Environments == null).ToList();
        }

        private void GetAppSettingsForEnvironment(int serialNumber)
        {
            modifiedAppSettings = commonModifiedAppSettings;
            var appSettings = new List<AppSetting>((ObservableCollection<AppSetting>)appSettings_grid.ItemsSource);
            var specificAppSettings = appSettings.Where(x => x.Key != null && x.Environments != null && x.Environments.Split(',').Contains(serialNumber.ToString())).ToList();
            foreach (var changedAppSetting in specificAppSettings)
            {
                var appSetting = modifiedAppSettings.FirstOrDefault(x => x.Key == changedAppSetting.Key);
                if (appSetting != null)
                {
                    modifiedAppSettings.First(x => x.Key == changedAppSetting.Key).Value = changedAppSetting.Value;
                }
                else
                {
                    modifiedAppSettings.Add(changedAppSetting);
                }
            }
        }

        private void CopyAppSettingsToChildFolders(string sourcePath)
        {
            FileInfo appSettings = new FileInfo(sourcePath.TrimEnd('\\') + "\\AppSettings.config");
            if (Directory.Exists(sourcePath.TrimEnd('\\') + "\\Lw.WebServices"))
                appSettings.CopyTo(sourcePath.TrimEnd('\\') + "\\Lw.WebServices\\AppSettings.config", true);
            if (Directory.Exists(sourcePath.TrimEnd('\\') + "\\Lw.WindowsServices"))
                appSettings.CopyTo(sourcePath.TrimEnd('\\') + "\\Lw.WindowsServices\\AppSettings.config", true);
        }

        #endregion

        private long GetDirectorySize(string p)
        {
            string[] files = Directory.GetFiles(p, "*.*");
            long size = 0;

            foreach (string name in files)
            {
                FileInfo info = new FileInfo(name);
                size += info.Length;
            }

            string[] directories = Directory.GetDirectories(p);
            foreach (var dir in directories)
            {
                size += GetDirectorySize(dir);
            }
            return size;
        }

        private DataTable GetDataTable(string path,string workbookName)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path, ReadOnly: true);
            Excel._Worksheet workSheet = xlWorkbook.Sheets[workbookName];

            int index = 0;
            object rowIndex = 2;

            DataTable dt = new DataTable();
            dt.Columns.Add("S.No");
            dt.Columns.Add("Nick Name");
            dt.Columns.Add("Environment Type");
            dt.Columns.Add("Server Path");
            dt.Columns.Add("App URL");
            dt.Columns.Add("Backup Path");
            dt.Columns.Add("BatchFile Start");
            dt.Columns.Add("BatchFile Stop");

            DataRow row;

            while (((Excel.Range)workSheet.Cells[rowIndex, 1]).Value2 != null)
            {
                rowIndex = 2 + index;
                row = dt.NewRow();
                row[0] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 1]).Value2);
                row[1] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 2]).Value2);
                row[2] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 3]).Value2);
                row[3] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 4]).Value2);
                row[4] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 5]).Value2);
                row[5] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 6]).Value2);
                row[6] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 7]).Value2);
                row[7] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, 8]).Value2);
                index++;
                dt.Rows.Add(row);
            }
            return dt;
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
                    var max = _parameters.Where(x => x.ReleaseType == ReleaseType.BackupandRelease && x.EnvironmentType == EnvironmentType.LessorPortal).Count() * 3 + _parameters.Where(x => x.ReleaseType == ReleaseType.BackupandRelease && x.EnvironmentType == EnvironmentType.BrokerPortal).Count() * 2 + _parameters.Where(x => x.ReleaseType == ReleaseType.ReleaseOnly && x.EnvironmentType == EnvironmentType.LessorPortal).Count() * 2 + _parameters.Where(x => x.ReleaseType == ReleaseType.ReleaseOnly && x.EnvironmentType == EnvironmentType.BrokerPortal).Count() + _parameters.Where(x => x.ReleaseType == ReleaseType.BackupOnly).Count() + 1;
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
                AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Error: " + ex.Message + " Inner Exception: " + (ex.InnerException?.Message) ?? string.Empty);
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

        private void openApplications(string[] urls)
        {
            foreach (var url in urls)
            {
                Process.Start(url);
            }
        }

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

        private void AppendToLogFile(string text)
        {
            if (!Directory.Exists(_logFilePath))
                Directory.CreateDirectory(_logFilePath);
            File.AppendAllLines(_logFileName, new string[] { text });
        }
    }

    static class Extensions
    {
        public static string ToMonthName(this DateTime dateTime)
        {
            return (CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month)).Substring(0, 3);
        }

        public static string ToCSV(this List<int> list)
        {
            string result = string.Empty;
            foreach (int i in list)
            {
                result += (i.ToString() + ", ");
            }
            return result.TrimEnd().TrimEnd(',');
        }

        public static string ToCSV(this List<string> list)
        {
            string result = string.Empty;
            foreach (var i in list)
            {
                result += (i + ", ");
            }
            return result.TrimEnd().TrimEnd(',');
        }

        private static Action EmptyDelegate = delegate () { };

        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }

    public class Parameters
    {
        public int SerialNumber { get; set; }
        public string NickName { get; set; }
        public string BatchFileStart { get; set; }
        public string BatchFileStop { get; set; }
        public string ServerPath { get; set; }
        public string BackupPath { get; set; }
        public string AppURL { get; set; }
        public EnvironmentType EnvironmentType { get; set; }
        public ReleaseType ReleaseType { get; set; }
    }

    public class GridParam
    {
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public bool Backup { get; set; }
        public bool Release { get; set; }
    }

    public enum EnvironmentType
    {
        LessorPortal = 0, BrokerPortal = 1
    }

    public enum ReleaseType
    {
        None = 0, ReleaseOnly = 1, BackupOnly = 2, BackupandRelease = 3
    }

    public class AppSetting
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Environments { get; set; }
    }

    public class Impersonator : IDisposable
    {
        private WindowsImpersonationContext _impersonatedUser = null;
        private IntPtr _userHandle;
        public Impersonator(string user, string userDomain, string password)
        {
            _userHandle = new IntPtr(0);
            bool returnValue = LogonUser(user, userDomain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref _userHandle);
            if (!returnValue)
                throw new ApplicationException("Login Failed!!!");
            WindowsIdentity newId = new WindowsIdentity(_userHandle);
            _impersonatedUser = newId.Impersonate();
        }
        #region IDisposable Members
        public void Dispose()
        {
            if (_impersonatedUser != null)
            {
                _impersonatedUser.Undo();
                CloseHandle(_userHandle);
            }
        }
        #endregion
        #region Interop imports/constants
        public const int LOGON32_LOGON_INTERACTIVE = 2;
        public const int LOGON32_LOGON_SERVICE = 3;
        public const int LOGON32_PROVIDER_DEFAULT = 0;
        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern bool LogonUser(String lpszUserName, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);
        #endregion
    }
}
