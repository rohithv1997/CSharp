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
        static void Main(string[] args)
        {
            bool flag = false;
            int ch, x;
            int n;
            Console.WriteLine("Enter No. of New Employees: ");
            n = Convert.ToInt32(Console.ReadLine());
            Employee[] many=new Employee[n];
            for (int i = 0; i < n; i++)
            {
                many[i] = new Employee();
                while (true)
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Menu");
                    Console.WriteLine("1. Add New Employee");
                    Console.WriteLine("2. View existing Employee");
                    Console.WriteLine("3. Customize the screen");
                    Console.WriteLine("4. Exit");
                    //int ch;
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            {
                                many[i].AcceptEmployeeDetails();
                                many[i].genEmailID();
                                flag = true;
                                Console.ReadKey();
                                break;
                            }

                        case 2:
                            {
                                if (flag == true)
                                {
                                    many[i].DisplayEmployeeDetails();
                                    Console.WriteLine("Enter 1 to Continue, 0 to exit");
                                    x = Convert.ToInt32(Console.ReadLine());
                                    if (x == 1) break;
                                    else if (x == 0) return;
                                }

                                else
                                {

                                    Console.WriteLine("\nEnter Details Before Displaying");
                                    Thread.Sleep(2000);
                                    break;
                                }
                                break;
                            }
                        case 3:
                            {
                                ConsoleChange.cc();
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Thank You For Using Our System");
                                Thread.Sleep(2000);
                                return;
                            }
                    }

                }

            }


        }
    }
}
