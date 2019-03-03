using EmployeeLeaveManagement;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EMS
{
    class HomePage
    {
        // public static object Odessa { get; private set; }
        static Employee[] many;
        static int n;
        static Clients[] cmany;
        static int n2;
        static void Main(string[] args)
        {
            bool flag = false,flag2=false;
            int ch, x;


            int i = 0;
            //for (int i = 0; i < n; i++)
            //{
            //    many[i] = new Employee();
            while (true)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View existing Employee");
                Console.WriteLine("3. Add New Client");
                Console.WriteLine("4. View existing Clients");
                Console.WriteLine("5. Customize the screen");
                Console.WriteLine("6. View Company Details");
                Console.WriteLine("7. Exit");
                //int ch;
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        {

                            Console.WriteLine("Enter No. of New Employees: ");
                            n = Convert.ToInt32(Console.ReadLine());
                            many = new Employee[n];
                            for (i = 0; i < n; i++)
                            {
                                many[i] = new Employee();
                                many[i].AcceptEmployeeDetails();
                                many[i].genEmailID();
                                flag = true;
                                Console.ReadKey();
                                //break;
                            }
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Search for EmployeeID: ");
                            string src = Console.ReadLine();
                            for (i = 0; i < n; i++)
                            {
                                if (many[i].accessEmployeeID() == src && flag == true)

                                //if (flag == true)
                                {
                                    many[i].DisplayEmployeeDetails();
                                    Console.WriteLine("Enter 1 to Continue, 0 to exit");
                                    x = Convert.ToInt32(Console.ReadLine());
                                    if (x == 1) break;
                                    else if (x == 0) return;
                                }

                                else
                                {

                                    Console.WriteLine("\nEnter Employee Details Before Displaying");
                                    Thread.Sleep(2000);
                                    break;
                                }
                            }
                            break;
                        }
                    case 3:
                        {

                            Console.WriteLine("Enter No. of New Clients: ");
                            n2 = Convert.ToInt32(Console.ReadLine());
                            cmany = new Clients[n2];
                            for (i = 0; i < n; i++)
                            {
                                cmany[i] = new Clients();
                                //cmany[i].retreiveclient();
                                flag2 = true;
                                Console.ReadKey();
                                //break;
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Search for Client: ");
                            string src = Console.ReadLine();
                            for (i = 0; i < n; i++)
                            {
                                if (cmany[i].retcname() == src && flag2 == true)

                                //if (flag == true)
                                {
                                    cmany[i].retreiveclient();
                                    Console.WriteLine("Enter 1 to Continue, 0 to exit");
                                    x = Convert.ToInt32(Console.ReadLine());
                                    if (x == 1) break;
                                    else if (x == 0) return;
                                }

                                else
                                {

                                    Console.WriteLine("\nEnter Client Details Before Displaying");
                                    Thread.Sleep(2000);
                                    break;
                                }
                            }
                            break;
                        }
                    case 5:
                        {
                            ConsoleChange.cc();
                            break;
                        }
                    case 6:
                        {
                            //Odessa.input();
                            Odessa.output();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Thank You For Using Our System");
                            Thread.Sleep(2000);
                            return;
                        }
                }

            }

            // }


        }
    }

}
