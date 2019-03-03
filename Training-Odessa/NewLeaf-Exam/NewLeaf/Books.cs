using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLeaf
{
    class Books:IBookInfo
    {
        public string AuthorName;
        public string propAuthorName
        {
            get { return AuthorName; }
            set { AuthorName = value; }
        }
        public string BookName;
        public string propBookName
        {
            get { return BookName; }
            set { BookName = value; }
        }
        public double BookPrice;
        public double propBookPrice
        {
            get { return BookPrice; }
            set
            {
                if (value >= 0) BookPrice = value;
                else throw new NegativePriceException("Price cannot be Negative");
            }
        }
        public double FinalPrice;
        public double propFinalPrice
        {
            get { return FinalPrice; }
            set { FinalPrice = value; }
        }
        public long ISBN;
        public long propISBN
        {
            get { return ISBN; }
            set { ISBN = value; }
        }
        public double OfferPercent;
        public double propOfferPercent
        {
            get { return OfferPercent; }
            set { OfferPercent = value; }
        }
        public double VATPercent;
        public double propVATPercent
        {
            get { return VATPercent; }
            set { VATPercent = value; }
        }
        public virtual void CalculatePrice()
        {
            propOfferPercent = 2.00;
            propVATPercent = 2.00;
        }
        public virtual void PrintBookDetails()
        {

        }
        public virtual void GetBookDetails()
        {

        }
    }
}
