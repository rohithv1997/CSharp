using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Selenium
{
    public class ActiTime
    {
        IWebDriver driver;

        [SetUp]
        public void init()
        {
            driver = new ChromeDriver();
        }

        internal void findTheCell(string comment)
        {
            int i ;
            string ID1 = "spent_2759_";
            string ID2 = "timeTrack[2759].commentImg[";
            i = (int)(DateTime.Now.DayOfWeek) + 1;
            i = i % 7;
            ID1 = string.Concat(ID1, i.ToString());
            ID2 = ID2 + i.ToString() + "]";

            driver.FindElement(By.Id(ID1)).SendKeys(ConfigManager.GetAppsettingValue("TimeLogged"));
            driver.FindElement(By.Id(ID2)).Click();
            driver.FindElement(By.Name("comment")).SendKeys(comment);
            driver.FindElement(By.Id("scbutton")).Click();
            if(DateTime.Now.DayOfWeek.Equals("Friday"))
                driver.FindElement(By.ClassName("switcher")).Click();
            driver.FindElement(By.Id("SubmitTTButton")).Click();
        }

        [Test]
        public void login()
        {
            driver.Url = ConfigManager.GetAppsettingValue("driverURL");
            driver.FindElement(By.Id("username")).SendKeys(ConfigManager.GetAppsettingValue("driverUsername"));
            driver.FindElement(By.Name("pwd")).SendKeys(ConfigManager.GetAppsettingValue("driverPassword"));
            driver.FindElement(By.Id("loginButton")).Click();
        }

        [TearDown]
        public void die()
        {
            driver.Close();
            driver.Quit();
            return; 
        }
    }
}
