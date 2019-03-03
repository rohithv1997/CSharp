using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Petroleum p;
            Console.WriteLine("Enter the Code for Product");
            int Option = Convert.ToInt32(Console.ReadLine());
            if (Option==1)
            {
                 p = new Petrol();
                p.Purification();
                p.Refinement();

              
            }
            else if(Option==2)
            {
               p = new Diesel();
                p.Purification();
                p.Refinement();
            }
            else if (Option == 2)
            {
                p = new NaturalGas();
                p.Purification();
                p.Refinement();
            }
        }
    }
}
