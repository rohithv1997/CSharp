using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Demo_1
{
    class Program
    {
        static void Main(string[] args)
        {
            BetterComparison c = new BetterComparison();
            c.Compare<int>(10, 20);
            c.Compare<string>("A", "a");
            c.Compare<Customer>(new Customer(), new Customer());
            BestComparison<int, string> c1 = new BestComparison<int, string>();
            c1.Compare(10, "10");


            List<int> intlist = new List<int>();
            //intlist.Insert()
            intlist.Add(10);
            //intlist.Add("1");
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer());
            Stack<string> stringstack = new Stack<string>();
            stringstack.Push("10");
            Queue<double> doublequeue = new Queue<double>();
            Dictionary<int, string> countries = new Dictionary<int, string>();
            countries.Add(1, "India");

            SortedDictionary<int, string> currencies = new SortedDictionary<int, string>();
            foreach(var x in countries)
            {
                Console.WriteLine(countries.Count);
            }
        }
    }
}
