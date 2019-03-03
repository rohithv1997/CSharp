using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EName { get; set; }
        //public string Department;
        public List<string> Skills { get; set; }
        public void getEmployeeDetails()
        {
            Console.WriteLine("Enter Employee ID");
            EmployeeID=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Name");
            EName = Console.ReadLine();
            Console.WriteLine("Enter Employee skills");
            Skills.Add(Console.ReadLine());
        }

        public void putEmployeeDetails()
        {
            Console.WriteLine("EmployeeID: {0}",EmployeeID);
            Console.WriteLine("Employee Name: {0}", EName);
            //Console.WriteLine("Employee Department: {0}", Department);
        }
    }
}
