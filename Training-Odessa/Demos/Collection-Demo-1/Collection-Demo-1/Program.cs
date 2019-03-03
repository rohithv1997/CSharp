using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_Demo_1
{
    class Program
    {
        ArrayList myarraylist = new ArrayList();
        Stack mystack = new Stack();
        Queue myqueue = new Queue();
        Hashtable myhash = new Hashtable();
        SortedList mysortedlist = new SortedList();
        static void Main(string[] args)
        {
            //new Program().DemoArrayList();
            //new Program().DemoStack();
            //new Program().DemoQueue();
            // new Program().DemoHashtable();
            new Program().DemoSortedList();

        }

        private void DemoSortedList()
        {
            mysortedlist.Add(4, "USA");
            mysortedlist.Add(3, "South Korea");
            mysortedlist[2] = "India";
            mysortedlist[1] = "Australia";
            //myhash.Add("India", "INR");
            //myhash["USA"] = "Dollar";
            mysortedlist[1] = "Austria";
           // mysortedlist.Add(4, "UK");
            foreach (DictionaryEntry item in mysortedlist)
            {
                Console.WriteLine(item.Key+ "-"+item.Value);
            }
            myhash.Contains(1);
            myhash.ContainsValue("UK");
           
        }

        private void DemoStack()
        {
            mystack.Push(1);
            mystack.Push(1.3);
            mystack.Push("Hi");
            mystack.Push(true);
            mystack.Push(new Customer());
           
            foreach (var item in mystack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Peek());
            Console.WriteLine(mystack.Contains(true));
            Console.WriteLine(mystack.Count);
          var x=  mystack.ToString();
            Console.WriteLine(x);
        }

        private  void DemoArrayList()
        {
            myarraylist.Add(1);
            myarraylist.Add(1.3);
            myarraylist.Add("Hi");
            myarraylist.Add(true);
            myarraylist.Add(new Customer());
            foreach (var item in myarraylist)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(myarraylist.Count);
            Console.WriteLine(myarraylist.Capacity);
            Console.WriteLine(myarraylist.Contains(1));
            object[] objArray=new object[myarraylist.Count];
            myarraylist.CopyTo(objArray);
            myarraylist.GetRange(1, 2);
            myarraylist.AddRange(mystack);
            myarraylist.Clear();
        }
    }
}
