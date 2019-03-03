using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee();
            Console.WriteLine("Pls Enter Age");
            //e1.propAge = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("UPDATED IS  AGE     {0}",e1.propAge);
            Console.WriteLine("Your user Name is {0}",e1.propUserName);
            e1.propPassword = "73237626372";
           // Console.WriteLine(e1.propPassword);
        }
    }
   
}
