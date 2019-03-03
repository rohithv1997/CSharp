using System;
using System.Collections;

namespace Collection_Demo_1
{
    internal class Customer:IEnumerable
    {
        public int CustID { get; set; }
        public string  Name { get; set; }
        public int Age { get; set; }
        public string  City { get; set; }
        public Customer()
        {
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}