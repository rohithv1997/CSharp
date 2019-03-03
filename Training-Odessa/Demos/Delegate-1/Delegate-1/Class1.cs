using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_1
{
    //Delegate Declaration
    public delegate double CalculatorDelegate(double x, double y);
    public class Program
    {
        public static void Main(string[] args)
        {
            Calculator c1 = new Calculator();
            //Instantiate Delegate Object
            CalculatorDelegate cd1 = new CalculatorDelegate(c1.Add);

            //Multi cast Delegate
            cd1 += c1.Sub;
            //Invoke
            var x = cd1.Invoke(10, 10);
            Console.WriteLine(x);
        }
    }
}
