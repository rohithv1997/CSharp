using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        //    public delegate void delegateGet();
        //    public delegate void delegatePut();
        static void Main(string[] args)
        {
            //Employee e1 = new Employee();
            //delegateGet dg1 = new delegateGet(e1.getEmployeeDetails);
            //dg1.Invoke();
            //delegatePut dp1 = new delegatePut(e1.putEmployeeDetails);
            //dp1.Invoke();
            List<Employee> EmployeeList = new List<Employee>()
        { new Employee() {EmployeeID=101,EName="Adam",Skills= new List<string>(){"C#","SQL"} },
        new Employee() {EmployeeID=102,EName="Eve",Skills= new List<string>(){"ForbiddenFruit","Fighting"} },
        new Employee () {EmployeeID=103,EName="Apple",Skills= new List<string>(){"Fruit","Cursed"} }
        };
            foreach (var item in EmployeeList)
            {
                Console.WriteLine(item.EmployeeID);
                Console.WriteLine(item.EName);
                foreach (var item2 in item.Skills)
                    Console.WriteLine(item2);
                Console.WriteLine();
            }
        }
    }
}
