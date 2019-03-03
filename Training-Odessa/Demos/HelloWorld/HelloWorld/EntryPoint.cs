using System;
using MyLibProject;
namespace HelloWorld
{
    class EntryPoint
    {
        static void Main(string[] args)
        {


            //int a, b;
            //Console.WriteLine("First Number");
            //a = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Second Number");
            //b = Convert.ToInt32(Console.ReadLine());

            ////new Calculator().Method1( a, b);
            ////Console.WriteLine(a);
            ////Console.WriteLine(b);
            //int A, S, M;
            //double D;
            //new Calculator().Operation(a,b,out A,out S,out M,out D);
            //Console.WriteLine(A);
            //Console.WriteLine(S);
            //Console.WriteLine(M);
            //Console.WriteLine(D);

            //Bill b1 = new Bill();
            //b1.CalculateTotalBill("B001", "9846244480", DateTime.Now, 100, 20, 4500, 50);
            //Bill b2 = new Bill();
            //b1.CalculateTotalBill("B002", "9846244481", DateTime.Now, 45, 20, 400, 540,99,49,45,34,100,25);
            //Student s1 = new Student();
            //s1.IncrementCounter();

            //Student s2 = new Student();
            //s2.IncrementCounter();
            //Console.WriteLine(Student.Counter);
            //BillDetails bd1 = new BillDetails();
            //bd1.BillId = "B001";
            //bd1.BillAmount = 20000;
            //bd1.ContactNumber = "3764736451374";
            //bd1.TotalItems = 10;
            //bd1.PrintBillDetails();
            Student s1 = new Student();
            //Console.WriteLine("Grade");
            s1.Grade = Student.GradeType.D;
            Console.WriteLine(Convert.ToInt32(Student.GradeType.B));
            s1.Gender = GenderType.Female;
            Console.WriteLine(s1.Grade);
            Console.WriteLine((int)s1.Grade);
            Console.ReadLine();
        }
    }
    
   
}
