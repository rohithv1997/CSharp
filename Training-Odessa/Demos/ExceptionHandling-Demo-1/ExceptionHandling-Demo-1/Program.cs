using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling_Demo_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               
               
                int No1, No2, Result;
                Console.WriteLine("Enter the First Number");
                No1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Second Number");
                No2 = Convert.ToInt32(Console.ReadLine());
                new Calculator().Operation();
                try
                {
                    int x;
                    Console.WriteLine("Enter some number");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Am from inner try try");
                }
                catch(Exception e1)
                {
                    Console.WriteLine("Am from Inner catch");
                    Console.WriteLine(e1.Message);
                }
                Console.WriteLine("Am from Outer try");
                Result = No1 / No2;
                Console.WriteLine(Result);
                Console.WriteLine("First Happy Customer");

              
            }

            //catch (DivideByZeroException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine(ex.StackTrace);
            //    Console.WriteLine(ex.Source);
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Am from Outer catch");
            }
            Console.WriteLine("Second Happy Customer");
        }
    }
}
