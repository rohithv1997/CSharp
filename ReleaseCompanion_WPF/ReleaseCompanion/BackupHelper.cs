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
        private void Backup(string sourcePath, string targetPath, string[] foldersToCopy=null)
        {
            string destPath = CreateBackupFolderParams(sourcePath, ref targetPath);
            try
            {
                string desDir = DirectoryCopy(sourceDirName: sourcePath, destDirName: targetPath, foldersToCopy: foldersToCopy, isRoot: true, fileExtensionsToExclude: new string[] { });
                var bytes = GetDirectorySize(desDir);
                decimal megaBytes = ((decimal)bytes / (1048576));
                progressLabel.Foreground = Brushes.Green;
                logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Backup Successful to \"" + desDir + "\"!!!Total Data Copied: " + megaBytes.ToString("0.00") + " MB");
                progressLabel.Foreground = Brushes.Black;
                if (_clearOldBackups)
                    ClearOldBackups(destPath, _numberOfBackupsToRetain);
            }
            catch (Exception e)
            {
                progressLabel.Foreground = Brushes.Red;
                progressLabel.Text += "\n" + e.Message;
                logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Error: " + e.Message);
                progressLabel.Foreground = Brushes.Black;
            }
        }

        private string CreateBackupFolderParams(string sourcePath, ref string targetPath)
        {
            DateTime today = DateTime.Today;
            string currentDateString = today.ToMonthName() + " " + today.Year + "\\" + today.Day + " " + today.ToMonthName() + " " + today.Year;
            var destPath = targetPath;
            targetPath += "\\" + currentDateString;
            progressLabel.Text = "Copying from " + sourcePath + ": ...";
            logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Copying from " + sourcePath);
            progressBar.Value++;
            TaskbarItemInfo.ProgressValue = progressBar.Value * progress;
            progressBar.Refresh();
            return destPath;
        }

        private string DirectoryCopy(string sourceDirName, string destDirName, string[] fileExtensionsToExclude, string[] foldersToCopy = null, bool isRoot = false, bool isRelease = false)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Error: Source directory does not exist or could not be found: " + sourceDirName);
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
                    logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Backup(s) deleted:- ");
                    int count = 0;
                    try
                    {
                        foreach (var directory in directoriesToDelete)
                        {
                            logHelper.AppendToLogFile(directory);
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
                        logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - " + count + " Old Backup(s) deleted successfully!!!");
                        progressLabel.Foreground = Brushes.Black;
                    }
                    catch (Exception e)
                    {
                        progressLabel.Foreground = Brushes.Red;
                        logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Error: " + e.Message);
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
    }
}
