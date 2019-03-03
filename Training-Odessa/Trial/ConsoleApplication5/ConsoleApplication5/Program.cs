using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    [bugreport("Rohith","123.456")]
    class Program
    {
        [bugreport("Adam","234.567")]
        [bugreport("Eve", "2234.567")]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            m1();
        }
        [bugreport("Adam", "234.567")]
        private static void m1()
        {
            Console.WriteLine("m1");
            //throw new NotImplementedException();
        }
    }
}
