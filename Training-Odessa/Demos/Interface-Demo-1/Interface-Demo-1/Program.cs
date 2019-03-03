using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Demo_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Circle c = new Circle();
            //Sphere s = new Sphere();

            //IArea a;

            //if (true)
            //{
            //    a = new Circle();
            //}
            //else
            //{
            //    a = new Sphere();
            //    a.Area();
            //}

            //IVolume v = new Sphere();
            //v.Volume();

            IArea a;
            a = new Circle();
            a.Area();
           

            a = new Sphere();
            a.Area();
             Console.ReadLine();
        }
    }
}
