using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
   
    class Employee
    {
        public void Print()
        {
            EmployeePayDetails.EmployeeTax t1 = new EmployeePayDetails.EmployeeTax();
            Console.WriteLine(t1.Year);
        }
        public int Id { get; set; }
      public  class EmployeePayDetails
        {
           public class EmployeeTax
            {
                public int Year;
            }
        }
    }
    class Products
    {
        struct ProductDetails
        {
            public string ProductName;
        }
     public enum Grade
        {
            A, B
        }

    }
    enum EmployeeGenderType
    {
        Male,Female
    }
}
