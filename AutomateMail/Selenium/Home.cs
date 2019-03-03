using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace Selenium
{
    class Home
    {
        public static string mailContent = null;
        static void Main(string[] args)
        {
            string actitimeComment = null;

            try
            {
                ExcelParser e = new ExcelParser();
                actitimeComment = e.excelparser();
                e.dispose();
                Logger.CreateLog(e);

                Mail m = new Mail();
                m.sendmail(mailContent);
                Logger.CreateLog(m);

                ActiTime at = new ActiTime();
                at.init();
                at.login();
                at.findTheCell(actitimeComment);
                at.die();
            }
            catch (Exception e)
            {
                Logger.CreateLog(e);
            }
            return;
        }
    }
}
