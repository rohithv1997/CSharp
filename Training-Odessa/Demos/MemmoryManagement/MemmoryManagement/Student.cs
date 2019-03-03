using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemmoryManagement
{
    class Student
    {
        public static string School { get; set; }
        private DateTime dateTime;
        private bool v;

        public int StudentID { get; set; }
        public string  StudentName { get; set; }

        public DateTime DOB { get; set; }
        public bool Status { get; set; }

        static Student()
        {
            School = "Navodaya";
            
        }
        public Student()
        {
            StudentID = 1;
            StudentName = "Don";
            School = "JNV";
        }
        //public Student(int StudentID, string StudentName)
        //{
        //    this.StudentID = StudentID;
        //    this.StudentName = StudentName;
        //}

        //public Student(int StudentID, string StudentName, DateTime dateTime, bool status)
        //{
        //    this.StudentID = StudentID;
        //    this.StudentName = StudentName;
        //    this.dateTime = dateTime;
        //    this.Status = status;
        //}

        ~ Student()
        {
            int x;
            x = 10;
            Console.WriteLine("Am done ");

        }
    }
}
