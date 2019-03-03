using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    //[Obsolete("Warning: salestax Deprecated", true)]
    //[Obsolete("Warning: salestax Deprecated")]
    class salestax
    {
        //[Obsolete("Warning: VAT Deprecated")]
        //[Obsolete("Warning: VAT Deprecated",true)]

        [Obsolete("Warning: id Deprecated",true)]
        public int id { get; set; }
        public void vat()
        {
            Console.WriteLine("Deprecated VAT");
        }
        public void gst()
        {
            Console.WriteLine("Current GST");
        }
    }
}
