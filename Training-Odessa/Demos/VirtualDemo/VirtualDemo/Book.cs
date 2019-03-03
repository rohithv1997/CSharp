;using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualDemo
{
    class Book
    {
        //Common Properties
        public void PrintBill()
        {

        }
        public virtual void Offer()
        {
            Console.WriteLine("10%");
        }
    }
    class Fiction : Book
    {

    }
    class NonFiction : Book
    {

    }
    class Academic : Book
    {
        public override void Offer()
        {
            Console.WriteLine("20%");
        }
    }
}
