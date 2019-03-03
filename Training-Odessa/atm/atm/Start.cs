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
            ConsoleKeyInfo kk;
            string pwd = "";
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("ATM Login");
                Console.WriteLine("Enter Account ID:");
                int q = new int();
                q = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Password:");
                
                do
                {
                    kk = Console.ReadKey(true);
                    if (kk.Key != ConsoleKey.Backspace && kk.Key!=ConsoleKey.Enter)
                    {
                        pwd += kk.KeyChar;
                        //if(kk.Key!=ConsoleKey.Enter)
                        Console.Write("*");
                    }
                    else if (kk.Key == ConsoleKey.Backspace && pwd.Length > 0)
                    {
                        pwd = pwd.Substring(0, pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                } while (kk.Key != ConsoleKey.Enter);
               
                int w = new int();
                w = Convert.ToInt32(pwd);
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
