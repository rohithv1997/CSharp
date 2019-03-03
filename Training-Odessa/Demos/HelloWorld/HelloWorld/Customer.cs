using System;

namespace HelloWorld
{
    sealed class Customer
    {
        int CustID; //Int32
        HelloWorld.Products.Grade CustomerGrade;
        string CustomerName;
        int Age;
       

        public void GetCustomerDetails()
        {
            Console.WriteLine("Enter Your ID");
            CustID =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Your Name");
            CustomerName = Console.ReadLine();
            Console.WriteLine("Enter Your Age");
            Age = Convert.ToInt32(Console.ReadLine());
        }
        public void PrintCustomerDetails()
        {
            Console.WriteLine("Your ID -{0} and Name is  {1}",CustID,CustomerName);
            Console.WriteLine("Age {0} ",Age);
        }
    }
}