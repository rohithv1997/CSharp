using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Demo_1
{
    class Comparison
    {
        public bool Compare(int x,int y)
        {
            return x.Equals(y);
        }
        public bool Compare(string x, string y)
        {
            return x.Equals(y);
        }
        public bool Compare(int x, double y)
        {
            return x.Equals(y);
        }
        public bool Compare(Customer x, Customer y)
        {
            return x.Equals(y);
        }

    }
}
