using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Model1Container m1c = new Model1Container();
            Teacher t = new Teacher() { Name = "Teacher1" };
            Student s1 = new Student() { Name = "Student1" };
            Student s2 = new Student() { Name = "Student2" };
            Student s3 = new Student() { Name = "Student3" };
            m1c.Students.Add(s1);
            m1c.Students.Add(s2);
            m1c.Students.Add(s3);
            m1c.Teachers.Add(t);
            m1c.SaveChanges();
            
        }
    }
}
