using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Constructor
{
    class Employee
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public Employee()
        {
            EmpID = 1;
            Name = "Don";
        }
        public Employee(int id, string name)
        {
            EmpID = id;
            Name = name;
        }
    }
    class Manager:Employee
    {
        public int NoOfEmployeesUnder { get; set; }
        public Manager()
        {
            NoOfEmployeesUnder = 3;
        }
        public Manager(int id,string name):base(id,name)
        {
          
        }
    }
}
