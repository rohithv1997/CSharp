using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveManagement
{
    static public class Odessa
    {
        static string name { get; set; }
        static string AddressLine1 { get; set; }
        static string AddressLine2 { get; set; }
        static string CEO { get; set; }
        static string COO { get; set; }
        static string Manager { get; set; }


        static void input()
        {
            name = "Odessa Inc.,";
            AddressLine1 = "18/2B, GGR Towers, Sarjapur Main Road";
            AddressLine2 = "Bellandur, Bengaluru, Karnataka 560103";
            CEO = "Mr. Madhu Natarajan";
            COO = "Mr. Jay Mehra";
            Manager = "Mr. Dinoop Unnikrishnan";
        }

        static public void output()
        {
            Odessa.input();
            Console.WriteLine("Company Details:");
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("Address: {0},{1}", AddressLine1, AddressLine2);
            Console.WriteLine("CEO: {0}", CEO);
            Console.WriteLine("COO: {0}", COO);
            Console.WriteLine("Manager: {0}", Manager);
        }
    }
}
