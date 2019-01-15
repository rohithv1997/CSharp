using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shell;

namespace ReleaseCompanion
{
    public partial class MainWindow : System.Windows.Window
    {
        private void CreateWindowsServices(string publishedLocation)
        {
            string tempPath = Path.Combine(publishedLocation, _foldersForWindowsService);
            DirectoryInfo tempPathDir = new DirectoryInfo(tempPath);


            if (!tempPathDir.Exists)
            {
                Directory.CreateDirectory(tempPath);
            }

            var filesToInclude = _filesForWindowsService;
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
                    logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Cleaning up old files from " + targetPath);
                    CleanUpFiles(targetPath);
                    logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Old files cleaned up from " + targetPath);
                }
                progressLabel.Text = "\nCopying to " + targetPath + ": ...";
                logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Copying from " + sourcePath);
                progressBar.Value++;
                TaskbarItemInfo.ProgressValue = progressBar.Value * progress;
                progressBar.Refresh();
                string desDir = DirectoryCopy(sourceDirName: sourcePath, destDirName: targetPath, fileExtensionsToExclude: _fileExtensionsToExclude, isRelease: true);
                var bytes = GetDirectorySize(sourcePath);
                decimal megaBytes = ((decimal)bytes / (1048576));
                logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Release Successful to \"" + desDir + "\"!!!\nTotal Data Copied: " + megaBytes.ToString("0.00") + " MB");
                progressLabel.Foreground = Brushes.Black;
            }
            catch (Exception e)
            {
                progressLabel.Foreground = Brushes.Red;
                progressLabel.Text += "\n" + e.Message;
                logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Error: " + e.Message);
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

        public void DoRelease()
        {
            var lessorPortals = _parameters.Where(x => (x.ReleaseType == ReleaseType.ReleaseOnly || x.ReleaseType == ReleaseType.BackupandRelease) && x.EnvironmentType == EnvironmentType.LessorPortal && !x.NickName.Contains("Local")).Select(x => x.NickName).ToList();
            if (lessorPortals.Any())
            {
                _environments.Append(lessorPortals.ToCSV());
            }
            else
            {
                var brokerPortals = _parameters.Where(x => (x.ReleaseType == ReleaseType.ReleaseOnly || x.ReleaseType == ReleaseType.BackupandRelease) && x.EnvironmentType == EnvironmentType.BrokerPortal && !x.NickName.Contains("Local")).Select(x => x.NickName).ToList();
                _environments.Append(brokerPortals.ToCSV());
            }
            var positionOfComma = _environments.ToString().LastIndexOf(',');
            if (positionOfComma > 0)
            {
                _environments.Remove(positionOfComma, 1);
                _environments.Insert(positionOfComma, " and");
                _environments.Append(" environments");
            }
            else
            {
                _environments.Append(" environment");
            }            
            Clipboard.SetText("Team," + Environment.NewLine + "Please refrain from using " + _environments + " for a while as we are doing a release." + Environment.NewLine + Environment.NewLine + "Thanks!");
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
                logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Starting the release.");
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
            Clipboard.SetText("Team," + Environment.NewLine + "Release has been completed successfully in " + _environments + Environment.NewLine + Environment.NewLine + "Thanks for your Co-operation!");
            MessageBox.Show(this, "Release Completed!!!", "Information");
        }
    }
}
