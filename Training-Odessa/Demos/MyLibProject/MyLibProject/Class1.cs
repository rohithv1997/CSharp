using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibProject
{
    public class Vendor
    {
        int vid;
      protected internal string Name;
      public  int Age;
    }
    class Vendor2:Vendor
    {
        public void M1()
        {
          
           
        }
    }
    class Vendor3:Vendor2
    {
        public void M1()
        {
            Console.WriteLine();
        }
    }
    class Asset
    {
        public void SomeMethod1()
        {
            Vendor v1 = new Vendor();
           
        }
    }
}
