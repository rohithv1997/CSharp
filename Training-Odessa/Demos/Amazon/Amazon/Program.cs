using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    class Program
    {
        static void Main(string[] args)
        {
            Vendor v1 = new Vendor();
            v1.VendorID = 1;
            v1.VendorName = "Apple INC";

            Products p1 = new Products();
            p1.ProductID = 100;
            p1.UnitPrice = 50000;
            p1.Name = "Iphone 6S";
            p1.VendorDetails = v1;

            MobilePhones iphone6s = new MobilePhones();
            iphone6s.MobileOS = OsType.IOS;

            Customer c1 = new Customer();
            c1.CustID = 1000;
            c1.Name = "Don";
            c1.Username = "don.j";
            c1.Password = "123";


            OrderDetails od1 = new OrderDetails();
            od1.OrderID = 1;
            od1.OrderDate = DateTime.Now;
            od1.Total = 50000;

            Order order1 = new Order();
            order1.Customer = c1;
            order1.Product = p1;
            order1.OrderDetail = od1;


        }
    }
}
