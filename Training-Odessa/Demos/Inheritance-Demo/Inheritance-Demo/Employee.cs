using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Demo
{
    class Employee
    {
        public int EmpID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Experience { get; set; }
        public double CTC { get; set; }
        public double MonthlySal { get; set; }

        public Employee()
        {
            //Console.WriteLine("Employee Constructor");
        }
        public void CalculateAttendance()
        {
            Console.WriteLine("Attendance");
        }
        public virtual  void DoWork()
        {
            Console.WriteLine("Common Work-Working With LW");
        }
        ~ Employee()
        {
            //Console.WriteLine("Employee Destructor");
        }
    }
    class Developer:Employee
    {

    }
    class QA:Employee
    {

    }
    class Manager:Employee
    {
        public Manager()
        {
            //Console.WriteLine("Manager Constructor ");
        }
        public int NoOfEmployeesWorkingUnder { get; set; }
      
        public new void DoWork()
        {
            Console.WriteLine("Common Work-Working With LW");
            Console.WriteLine("Managing Employees");
        }
        ~ Manager()
        {
            //Console.WriteLine("Manager Destructor ");
        }

    }

    class PEmployee:Employee
    {
        
    }
    class BA:PEmployee
    {
        public override void DoWork()
        {
            base.DoWork();
        }
    }
    class Intern:BA
    {
        public override void DoWork()
        {
            base.DoWork();
            Console.WriteLine()
        }
    }
}
