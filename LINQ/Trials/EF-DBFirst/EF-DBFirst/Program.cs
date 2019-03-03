using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            AdventureWorksEntities db = new AdventureWorksEntities();
           var xxx= db.Employees.Include("EmployeePayHistories").Select(x => x);
            foreach (var item in xxx)
            {
                Console.WriteLine(item.EmployeeID);
                var p = item.EmployeePayHistories;
                foreach (var item2 in p)
                {
                    Console.WriteLine(item2.Rate);
                }

            }
        }
    }
}
