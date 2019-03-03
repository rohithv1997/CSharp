using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling_Demo2
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
                if (No2>No1)
                {
                    DivisorIsBiggerException ex = new DivisorIsBiggerException("You are not suppose to divide a number by a bigger one");
                    throw ex;
                }
                Result = No1 / No2;
                Console.WriteLine(Result);
           
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("I Should Execute at any Cost");
            }
        }
    }
}
