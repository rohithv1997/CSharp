using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial1
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello Rohith");
    //        Console.ReadLine();
    //       // Console.ReadLine();
    //    }
    //}

    //[‎02-‎01-‎2018 10:14 AM]
    //Sreenath Selvaraj: 
    //check the above program

    public delegate void agentdelegate();
    class Program
    {
        delegate void Printer();

        static void Main()

        {
            //List<Printer> printers = new List<Printer>();
            //int i = 0;
            //for (; i < 10; i++)
            //{
            //    printers.Add(delegate { Console.WriteLine(i); });
            //}

            //foreach (var printer in printers)
            //{
            //    printer();
            //}

            //ConsoleKeyInfo kkk;
            //string pwd="";
            //do
            //{
            //    kkk = Console.ReadKey(true);
            //    if (kkk.Key != ConsoleKey.Backspace && kkk.Key != ConsoleKey.Enter)
            //    {
            //        pwd += kkk.KeyChar;
            //        Console.Write("*");
            //    }
            //    else if (kkk.Key == ConsoleKey.Backspace && pwd.Length>0)
            //    {
            //        pwd=pwd.Substring(0,pwd.Length-1);
            //        Console.Write("\b \b");
            //    }
            //} while (kkk.Key != ConsoleKey.Enter);
            //Console.WriteLine(pwd);
            publisher p1 = new publisher();
            subscriber s1 = new subscriber();
            s1.subscribe(p1);
            p1.trigger(true);

        }

    }
}