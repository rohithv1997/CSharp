using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Calculator
    {
        public void Method1( int x, int y)
        {
            x += 10;
            y += 10;
            Console.WriteLine("X-"+x);
            Console.WriteLine("Y-" + y);
        }

        public void Operation(int x,int y,out int Add,out int Sub,out int Mult,out double Div)
        {
            Add = x + y;
            Sub = x - y;
            Mult = x * y;
            Div = x / y;
        }
    }
}
