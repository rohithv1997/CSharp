using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    struct OrderDetails
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public double  Total { get; set; }
    }
}
