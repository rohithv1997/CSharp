using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Demo_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Sphere s = new Sphere();
            IArea sa = new Sphere();
            sa.GetDetails();
            IVolume sv = new Sphere();
            sv.GetDetails();
        }
    }
}
