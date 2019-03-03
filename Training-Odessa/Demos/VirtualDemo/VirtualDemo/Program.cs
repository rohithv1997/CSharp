using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b;
            Console.WriteLine("Enter the Code for Book");
            Console.WriteLine("1-Fiction");
            Console.WriteLine("2-Non Fiction");
            Console.WriteLine("3-Academic");
            Console.WriteLine("4-Others");
            int Option = Convert.ToInt32(Console.ReadLine());
            if (Option==1)
            {
                b = new Fiction();
                b.Offer();
            }
            else if(Option==2)
            {
                b = new NonFiction();
                b.Offer();
            }
            else if(Option==3)
            {
                b = new Academic();
                b.Offer();
            }
            else if(Option==4)
            {
                b = new Book();
                b.Offer();
            }
        }
    }
}
