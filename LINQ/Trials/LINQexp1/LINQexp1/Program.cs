using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQexp1
{

    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> Employeelist = new List<Employee>()
            {
                new Employee {ID=1,Name="Jeeva",Gender='M' },
                 new Employee {ID=2,Name="Kani",Gender='F' },
                  new Employee {ID=3,Name="Raj",Gender='M' },

            };

            //var Result = from employee in Employeelist where employee.Gender=='M' select employee;
            var Result = Employeelist.Where(e => e.Gender == 'M').Select(e => e);
            foreach (var employee in Result)
            {
                Console.WriteLine(employee.Name + "\t" + employee.ID);
            }
            string[] famousQuotes ={
                "Advertising is legalized lying",
                "Advertising is the greatest art form of the twentieth century"
            };

            var query1 = famousQuotes.Select(s => s.Split(' ')).Distinct();
            foreach(var items in query1)
            {
                //foreach(var item in items)
                       Console.WriteLine(items);
            }
            //string s = "Abracadabra";
            //s.Substring(0, 15);
            Console.WriteLine(DateTime.Now.Month);

            var array1 = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            array1.Sort();


        }
    }
}
