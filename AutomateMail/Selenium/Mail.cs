using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Selenium
{
    class Mail
    {
        public void sendmail(string body)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(ConfigManager.GetAppsettingValue("FromMailId"));
            mailMessage.To.Add(new MailAddress(ConfigManager.GetAppsettingValue("ToMailId")));
            string ccs = ConfigManager.GetAppsettingValue("CCMailIds");
            foreach (string CCEMailId in ccs.Split(','))
            {
                mailMessage.CC.Add(new MailAddress(CCEMailId));
            }
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = ConfigManager.GetAppsettingValue("MailSubject");
            mailMessage.Body = body;

            SmtpClient sClient = new SmtpClient(ConfigManager.GetAppsettingValue("smtpClient"));
            sClient.Host = ConfigManager.GetAppsettingValue("smtpHost");
            sClient.UseDefaultCredentials = false;
            sClient.Credentials = new NetworkCredential
                    (ConfigManager.GetAppsettingValue("FromMailId"), 
                     ConfigManager.GetAppsettingValue("FromMailPassword"), 
                     ConfigManager.GetAppsettingValue("smtpDomain"));
            sClient.Port = Convert.ToInt32(ConfigManager.GetAppsettingValue("smtpPort"));
            sClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            sClient.EnableSsl = true;
            sClient.Send(mailMessage);
            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
        }


        public static void InitialiseMail()
        {
            Home.mailContent += "<head>" + "\n";
            Home.mailContent += "<style>" + "\n";
            Home.mailContent += "table#t01 {  " + "\n";
            Home.mailContent += "width: 100 %;" + "\n";
            Home.mailContent += "text-align: left;" + "\n";
            Home.mailContent += "}" + "\n";
            Home.mailContent += "table#t01, th#t01, td#01 {" + "\n";
            Home.mailContent += "border: 1px solid black;" + "\n";
            Home.mailContent += "border-collapse: collapse;" + "\n";
            Home.mailContent += "}" + "\n";
            Home.mailContent += "th#t01, td#t01, tr#t01 { padding: 15px;" + "\n";
            Home.mailContent += "text-align: left;}" + "\n";
            Home.mailContent += "table#t01 th{" + "\n";
            Home.mailContent += "background-color: black;" + "\n";
            Home.mailContent += "color: white;}" + "\n";
            Home.mailContent += "</style>" + "\n";
            Home.mailContent += "</head>" + "\n";
            Home.mailContent += "<body>" + "\n";
            Home.mailContent += "Hi,<br/>Today’s Log:<br/>" + "\n";
            Home.mailContent += "<table id=" + "t01" + ">" + "\n";
            Home.mailContent += "<tr>" + "\n";
        }
    }
}
