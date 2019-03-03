using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    class Products
    {
        public int ProductID { get; set; }
        public double UnitPrice { get; set; }
        public string Name { get; set; }
        public Vendor VendorDetails { get; set; }
        public CategoryType category { get; set; }
    }
}
