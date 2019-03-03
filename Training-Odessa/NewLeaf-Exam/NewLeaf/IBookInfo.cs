using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLeaf
{
    public interface IBookInfo
    {
        string propBookName { get; set; }
        string propAuthorName { get; set; }
        long propISBN { get; set; }
        double propFinalPrice { get; set; }
        double propBookPrice { get; set; }
        double propOfferPercent { get; set; }
        double propVATPercent { get; set; }
        void GetBookDetails();
        void PrintBookDetails();
    }
}
