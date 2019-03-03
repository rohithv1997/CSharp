using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace atm
{
    class Start
    {

        static void Main(string[] args)
        {
            atmmachine one = new atmmachine();
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("ATM Login");
                Console.WriteLine("Enter Account ID:");
                int q = new int();
                q = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Password:");
                int w = new int();
                w = Convert.ToInt32(Console.ReadLine());
                if (q < 10000 && q > 99999)
                {
                    Console.WriteLine("Invalid User ID");
                }
                if (w < 10000 && w > 99999)
                {
                    Console.WriteLine("Invalid Password");
                }
                else
                {
                    one.signin(q, w);
                    flag = false;

                }

            }

        }
    }
}
