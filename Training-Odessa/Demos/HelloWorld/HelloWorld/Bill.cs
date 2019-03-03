using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Bill
    {
       

        public void CalculateTotalBill(string billID,string contactNumber,DateTime date,params double[] Items)
        {
            Console.WriteLine("------------Bill----------");
            Console.WriteLine("Bill Number-{0}",billID);
            Console.WriteLine("ContactNumber-{0}", contactNumber);
            Console.WriteLine("Bill Date-{0}", date);
            double Sum = 0;
            foreach (var item in Items)
            {
                Sum += item;
            }
            Console.WriteLine("Bill Total-{0}",Sum );
        }
        public void CalculateBill2Fixed(string BillId,double [] Items)
        {

        }
    }
}
