using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://en.wikipedia.org/wiki/List_of_Person_of_Interest_episodes";
            HtmlWeb web = new HtmlWeb();
            var doc1 = web.Load(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(doc1.DocumentNode.InnerHtml);
            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[4]"))
            {

                //if (table.SelectNodes("tr[3]") != null)
                //    for (int i = 1; i < 12; i++)
                //    {
                       // string s = "tr" + "[" + i + "]";
                        if (table.SelectNodes("tr") != null)
                        {
                            foreach (HtmlNode row in table.SelectNodes("tr"))
                            {

                                if (row.SelectNodes("td") != null)
                                    foreach (HtmlNode cell in row.SelectNodes("td"))
                                    {
                                        Console.WriteLine("cell data: " + cell.InnerText);
                                    }
                                if (row.SelectNodes("th") != null)
                                    foreach (HtmlNode cell in row.SelectNodes("th"))
                                    {
                                        Console.WriteLine("cell header: " + cell.InnerText);
                                    }

                            }
                    //}
                }
            }

        }
    }
}
