using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class PreDefinedDelegates
    {
        static void Main(string[] args)
        {
            int n, p;
            double r;
            Console.WriteLine("Year?");
            n = Convert.ToInt32(Console.ReadLine());
            Predicate<int> predicateHelper = (n2) =>
                {
                    //if (n2 % 4 != 0) return false;
                    //else if (n2 % 100 != 0) return true;
                    //else if (n2 % 400 != 0) return false;
                    //return true;
                    return ((n2 % 4 == 0 && n2 % 100 != 0 || n2 % 400 == 0) ? true : false);

                };
            Console.WriteLine(predicateHelper(n));

            p = Convert.ToInt32(Console.ReadLine());
            n = Convert.ToInt32(Console.ReadLine());
            r = Convert.ToDouble(Console.ReadLine());
            Action<int, int, Double> actionHelper = (p2, n2, r2) =>
            {
                Console.WriteLine(Convert.ToDouble(p2 * n2 * r2) / 100.0);
            };
            actionHelper(p, n, r);

            int l, b;
            l = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            Func<int, int,int> funcHelper = (l2, b2) => (l2 * b2);
            Console.WriteLine(funcHelper(l, b));



        }
    }
}
