using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeatures_FrameworkAndLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            //Implicitly Typed Local Variables
            var x = 10;
            var c = new Customer();


            //Implicitly Typed Array

             var marks =new[]{ 1, 2, 3, 4 };


            //Implicitly Typed Class-Anonymous Type

            var mycar = new { ID=1,Brand="BMW",Price=45};

            //Null able Type
            //Object Initializer
            //Collection Initializer
            //Auto Implemented Properties


            //Partial Classes

           // Calculator c = new Calculator();
            


        }
    }
}
