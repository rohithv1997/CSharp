using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Student
    {
      public  enum GradeType
        {
            A,
            B =34,
            C,
            D =50
        }
        public string ID;
        public string Name;
        public int age;
        public GradeType Grade;
        public GenderType Gender;
    }
    enum GenderType
    {
        Male,Female
    }
    class Teachers
    {
        public Student.GradeType Grade;
        public GenderType Gender;
    }
}
