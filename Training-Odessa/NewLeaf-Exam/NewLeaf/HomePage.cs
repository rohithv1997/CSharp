using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLeaf
{
    class HomePage
    {

        static void Main(string[] args)
        {
            int choice;
            Console.WriteLine("Enter User Name:");
            Console.ReadLine();
            Publisher objectPublisher = new Publisher();
            Subsciber objectSubscriber = new Subsciber();
            objectSubscriber.Subscribe(objectPublisher);
            objectPublisher.Trigger();
            while (true)
            {
                Books baseObjectBook;
                try
                {
                    Console.Clear();
                    Console.WriteLine("Book Menu");
                    Console.WriteLine("1.Computer Books");
                    Console.WriteLine("2.Physics Books");
                    Console.WriteLine("3.Chemistry Books");
                    Console.WriteLine("4.Maths Books");
                    Console.WriteLine("5.Biology Books");
                    Console.WriteLine("6.Other Books");
                    Console.WriteLine("99.Exit");
                    Console.Write("Choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                bool flag = true;
                                baseObjectBook = new ComputerBooks();
                                int ComputerMenuChoice;
                                while (flag)
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Computer Books Menu");
                                        Console.WriteLine("1.Add Book");
                                        Console.WriteLine("2.View Book");
                                        Console.WriteLine("99.Exit");
                                        Console.Write("Choice: ");
                                        ComputerMenuChoice = Convert.ToInt32(Console.ReadLine());
                                        switch (ComputerMenuChoice)
                                        {
                                            case 1:
                                                {
                                                    baseObjectBook.GetBookDetails();
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    baseObjectBook.PrintBookDetails();
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            case 99:
                                                {
                                                    Console.WriteLine("Bye.");
                                                    flag = false;
                                                    break;
                                                }
                                            default:
                                                {
                                                    Console.WriteLine("Wrong Choice");
                                                    break;
                                                }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            {
                                bool flag = true;
                                baseObjectBook = new PhysicsBooks();
                                int PhysicsMenuChoice;
                                while (flag)
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Physics Books Menu");
                                        Console.WriteLine("1.Add Book");
                                        Console.WriteLine("2.View Book");
                                        Console.WriteLine("99.Exit");
                                        Console.Write("Choice: ");
                                        PhysicsMenuChoice = Convert.ToInt32(Console.ReadLine());
                                        switch (PhysicsMenuChoice)
                                        {
                                            case 1:
                                                {
                                                    baseObjectBook.GetBookDetails();
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    baseObjectBook.PrintBookDetails();
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            case 99:
                                                {
                                                    Console.WriteLine("Bye.");
                                                    flag = false;
                                                    break;
                                                }
                                            default:
                                                {
                                                    Console.WriteLine("Wrong Choice");
                                                    break;
                                                }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                Console.ReadKey();
                                break;
                            }
                        case 3:
                            {
                                bool flag = true;
                                baseObjectBook = new ChemistryBooks();
                                int ChemistryMenuChoice;
                                while (flag)
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Chemistry Books Menu");
                                        Console.WriteLine("1.Add Book");
                                        Console.WriteLine("2.View Book");
                                        Console.WriteLine("99.Exit");
                                        Console.Write("Choice: ");
                                        ChemistryMenuChoice = Convert.ToInt32(Console.ReadLine());
                                        switch (ChemistryMenuChoice)
                                        {
                                            case 1:
                                                {
                                                    baseObjectBook.GetBookDetails();
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    baseObjectBook.PrintBookDetails();
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            case 99:
                                                {
                                                    Console.WriteLine("Bye.");
                                                    flag = false;
                                                    break;
                                                }
                                            default:
                                                {
                                                    Console.WriteLine("Wrong Choice");
                                                    break;
                                                }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                Console.ReadKey();
                                break;
                            }
                        case 4:
                            {
                                bool flag = true;
                                baseObjectBook = new MathsBooks();
                                int MathsMenuChoice;
                                while (flag)
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Maths Books Menu");
                                        Console.WriteLine("1.Add Book");
                                        Console.WriteLine("2.View Book");
                                        Console.WriteLine("99.Exit");
                                        Console.Write("Choice: ");
                                        MathsMenuChoice = Convert.ToInt32(Console.ReadLine());
                                        switch (MathsMenuChoice)
                                        {
                                            case 1:
                                                {
                                                    baseObjectBook.GetBookDetails();
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    baseObjectBook.PrintBookDetails();
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            case 99:
                                                {
                                                    Console.WriteLine("Bye.");
                                                    flag = false;
                                                    break;
                                                }
                                            default:
                                                {
                                                    Console.WriteLine("Wrong Choice");
                                                    break;
                                                }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                Console.ReadKey();
                                break;
                            }
                        case 5:
                            {
                                bool flag = true;
                                baseObjectBook = new BiologyBooks();
                                int BiologyMenuChoice;
                                while (flag)
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Biology Books Menu");
                                        Console.WriteLine("1.Add Book");
                                        Console.WriteLine("2.View Book");
                                        Console.WriteLine("99.Exit");
                                        Console.Write("Choice: ");
                                        BiologyMenuChoice = Convert.ToInt32(Console.ReadLine());
                                        switch (BiologyMenuChoice)
                                        {
                                            case 1:
                                                {
                                                    baseObjectBook.GetBookDetails();
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    baseObjectBook.PrintBookDetails();
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            case 99:
                                                {
                                                    Console.WriteLine("Bye.");
                                                    flag = false;
                                                    break;
                                                }
                                            default:
                                                {
                                                    Console.WriteLine("Wrong Choice");
                                                    break;
                                                }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                Console.ReadKey();
                                break;
                            }
                        case 6:
                            {
                                bool flag = true;
                                baseObjectBook = new OtherBooks();
                                int OthersMenuChoice;
                                while (flag)
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Other Books Menu");
                                        Console.WriteLine("1.Add Book");
                                        Console.WriteLine("2.View Book");
                                        Console.WriteLine("99.Exit");
                                        Console.Write("Choice: ");
                                        OthersMenuChoice = Convert.ToInt32(Console.ReadLine());
                                        switch (OthersMenuChoice)
                                        {
                                            case 1:
                                                {
                                                    baseObjectBook.GetBookDetails();
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    baseObjectBook.PrintBookDetails();
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            case 99:
                                                {
                                                    Console.WriteLine("Bye.");
                                                    flag = false;
                                                    break;
                                                }
                                            default:
                                                {
                                                    Console.WriteLine("Wrong Choice");
                                                    break;
                                                }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                Console.ReadKey();
                                break;
                            }
                        case 99:
                            {
                                Console.WriteLine("Bye.");
                                Console.ReadKey();
                                return;
                            }
                        default:
                            {
                                Console.WriteLine("Wrong Choice. Retry");
                                Console.ReadKey();
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
        }



    }
}
