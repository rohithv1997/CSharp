using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling_Demo_1
{
    class Calculator
    {
        public void Operation()
        {
            int No1, No2, Result;
            Console.WriteLine("Enter the First Number");
            No1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Second Number");
            No2 = Convert.ToInt32(Console.ReadLine());

            Result = No1 / No2;
            Console.WriteLine(Result);
        }
    }
}
