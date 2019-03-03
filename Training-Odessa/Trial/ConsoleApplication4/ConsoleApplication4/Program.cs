using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Globalization;

namespace ConsoleApplication4
{
    class Program
    {   
        static void Main(string[] args)
        {
            salestax s = new salestax();
            s.vat();
            s.gst();
            Console.WriteLine("Hello, world!");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.Now.Hour.GetType());
            Console.WriteLine(DateTime.Now.ToString("tt", CultureInfo.InvariantCulture).Equals("AM"));
        }
    }
}
