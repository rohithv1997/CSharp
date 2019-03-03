using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionOverloading
{
    class Program
    {
        static void Main(string[] args)
        {

            int x;
            double y;
            Console.WriteLine("Enter First Number");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Number");
            y = Convert.ToDouble(Console.ReadLine());
            new Calculator().Add(x, y);
           
            
        }
    }
}
