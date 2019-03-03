using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    struct BillDetails
    {
      public  string BillId;
      public DateTime Date;
      public string ContactNumber;
      public int TotalItems;
      public double BillAmount;
       

        public void PrintBillDetails()
        {
            Console.WriteLine(BillId);
            Console.WriteLine(Date);
            Console.WriteLine(ContactNumber);
            Console.WriteLine(TotalItems);
            Console.WriteLine(BillAmount);

        }

    }
}
