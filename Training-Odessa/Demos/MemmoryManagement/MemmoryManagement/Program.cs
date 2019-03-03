using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemmoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {

            OdessaCEO CEO1 = OdessaCEO.CreateCEO();
            CEO1.MeetingWithCEO();
            OdessaCEO CEO2 = OdessaCEO.CreateCEO();
            CEO2.MeetingWithCEO();


            //Console.WriteLine(Student.School);//Navodaya

            //Student s1 = new Student();
            //Console.WriteLine(Student.School);//JNV



            //Student s2 = new Student(2,"Anu");
            //Student s3 = new Student(3, "Bony", DateTime.Now.AddYears(-30), true);
            //Console.WriteLine(s1.StudentID);
            //Console.WriteLine(s1.StudentName);
            //Console.WriteLine(s1.DOB);
            //Console.WriteLine(s1.Status);
            Console.ReadLine();
        }
    }
}
