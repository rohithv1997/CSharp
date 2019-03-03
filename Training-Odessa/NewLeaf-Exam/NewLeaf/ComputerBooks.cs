using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLeaf
{
    class ComputerBooks : Books
    {
       



        public override void GetBookDetails()
        {
            Console.WriteLine("Input Computer Book Details");
            Console.WriteLine("Enter Name of the Book: ");
            propBookName = Console.ReadLine().ToString();
            Console.WriteLine("Enter Name of the Author: ");
            propAuthorName = Console.ReadLine();
            Console.WriteLine("Enter Price of the Book: ");
            propBookPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter ISBN of the Book: ");
            propISBN = Convert.ToInt64(Console.ReadLine());
        }
        public override  void CalculatePrice()
        {
            propOfferPercent = Convert.ToDouble(10d);
            propVATPercent = Convert.ToDouble(2d);
        }
        public override void PrintBookDetails()
        {
            double calculatedOfferPrice = (double)propBookPrice * 10d / (double)100d;
            double calculatedVATPrice = (double)propBookPrice * 2d / (double)100d;
            propFinalPrice = (double)propBookPrice - calculatedOfferPrice + calculatedVATPrice;
            Console.WriteLine("Book Details");
            Console.WriteLine("Title: {0}", propBookName);
            Console.WriteLine("Author: {0}", propAuthorName);
            Console.WriteLine("ISBN: {0}", propISBN);
            Console.WriteLine("Actual Price: {0}", propBookPrice);
            Console.WriteLine("Offer Price: "+ calculatedOfferPrice);
            Console.WriteLine("VAT: "+ calculatedVATPrice);
            Console.WriteLine("Final Price: "+ propFinalPrice);
            Console.ReadKey();
        }
    }
}
