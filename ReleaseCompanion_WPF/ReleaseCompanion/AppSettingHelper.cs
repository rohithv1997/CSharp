using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Xml;

namespace ReleaseCompanion
{
    public partial class MainWindow : System.Windows.Window
    {
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
                logHelper.AppendToLogFile(DateTime.Now.ToLongTimeString() + " - Following Key(s) were newly added:-");
                progressLabel.Foreground = Brushes.Cyan;
                foreach (var key in newKeys)
                {
                    progressLabel.Text += "\n" + key;
                    logHelper.AppendToLogFile(key);
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
    }
}
