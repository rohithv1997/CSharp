using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    class Order
    {
        public OrderDetails OrderDetail { get; set; }
        public Customer Customer { get; set; }
        public Products Product { get; set; }
    }

   
}
