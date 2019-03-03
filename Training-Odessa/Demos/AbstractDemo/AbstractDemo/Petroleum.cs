using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDemo
{
   abstract class Petroleum
    {
        //Common Properties
        public void Purification()
        {
            Console.WriteLine("Common Purification Methods");
        }
        public abstract void Refinement();
       
    }
    class Petrol : Petroleum
    {
        public override void Refinement()
        {
            Console.WriteLine("Refinement Techniques for Petrol");
        }
    }
    class Diesel : Petroleum
    {
        public override void Refinement()
        {
            Console.WriteLine("Refinement Techniques for Diesel");
        }
    }
    class NaturalGas : Petroleum
    {
        public override void Refinement()
        {
            Console.WriteLine("Refinement Techniques for Natural Gas");
        }
    }
}
