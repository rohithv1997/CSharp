using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Selenium
{
    class ExcelParser
    {
        public static string content;

        public string excelparser()
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(ConfigManager.GetAppsettingValue("ExcelFilePath"));
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            Mail.InitialiseMail();
            Excel.Range row1 = xlWorksheet.Rows[1];
            Excel.Range row2 = xlWorksheet.Rows[2];

            int i = 0;
            foreach (Excel.Range r in row1.Cells)
            {
                if (i < 6)
                {
                    Home.mailContent += ("<th>" + r.Value.ToString() + "</th>"+"\n");
                    i++;
                }
                else break;
            }
            Home.mailContent += "</tr>"+"\n";
            Home.mailContent += "<tr>"+"\n";

            i = 1;
            string[] arr;
            StringBuilder sb = new StringBuilder();

            foreach (Excel.Range r in row2.Cells)
            {
                if (i < 7)
                {
                    arr = r.Value.ToString().Split('\n');
                    if (i == 2 || i == 3)
                    {
                        content += (r.Value.ToString());
                        if (i == 2) content += ("\n");

                        foreach (var item in arr)
                        {
                            sb.Append(item);
                            sb.Append("<br />");
                        }
                    }
                    if (i == 5)
                    {
                        var link = r.Hyperlinks.OfType<Hyperlink>().ToList();
                        if (link.Any())
                        {
                            foreach (var item in link)
                            {
                                char a = '"';
                                sb.Append("<a href=");
                                sb.Append(a.ToString());
                                sb.Append(item.Address);
                                sb.Append(a.ToString() + ">");
                                sb.Append(item.TextToDisplay);
                                sb.Append("</a><br />");
                            }
                        }
                        else sb.Append(r.Value);
                    }

                    if (i == 1) Home.mailContent += ("<td>" + r.Value.ToString("MMMM dd, yyyy") + "</td>"+"\n");
                    else if (i == 3 || i == 2 || i == 5) Home.mailContent += ("<td>" + sb.ToString() + "</td>"+"\n");
                    else Home.mailContent += ("<td>" + r.Value.ToString() + "</td>"+"\n");
                    sb.Clear();
                    i++;
                }
                else break;
            }
            Home.mailContent += "</tr>"+"\n";
            Home.mailContent += "</table>"+"\n";
            Home.mailContent += "Regards,<br/>";
            Home.mailContent += ConfigManager.GetAppsettingValue("SenderName");
            Home.mailContent += "</body>";

            xlWorkbook.Close();
            xlWorkbook = null;
            xlApp.Quit();
            xlApp = null;

            return content;
        }

        

        public void dispose()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

    }
}
