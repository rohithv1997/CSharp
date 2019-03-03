using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://results.kongu.edu/allresout.php?regno=14CSR199-EVEN_2016-MAY_2017";
            HtmlWeb web = new HtmlWeb();
            var doc1 = web.Load(url);
            HtmlDocument doc = new HtmlDocument();
           // List<Queue<string>> v = new List<Queue<string>>();
            doc.LoadHtml(doc1.DocumentNode.InnerHtml);
            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[2]"))
            {
                Console.WriteLine("Found: " + table.Id);
                List<string> q = new List<string>();
                if (table.SelectNodes("tr") != null)
                {
                    foreach (HtmlNode row in table.SelectNodes("tr"))
                    {
                        Console.WriteLine("row");
                        if (row.SelectNodes("td|th") != null)
                            foreach (HtmlNode cell in row.SelectNodes("td|th"))
                            {
                                q.Add(cell.InnerText);
                                Console.WriteLine("cell data: " + cell.InnerText);
                            }
                    }
                }
                Console.ReadKey();
                foreach(var item in q)
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
            }
        }
    }
}
