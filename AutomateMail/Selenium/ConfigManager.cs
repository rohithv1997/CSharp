using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Selenium
{
    internal class ConfigManager
    {
        public static string GetAppsettingValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
