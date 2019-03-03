using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Department
    {
        int DepartmentId;
        public int propDepartmentId2
        {
            get { return DepartmentId; }
            set { DepartmentId = value; }
        }
        string Name2;
        public string propName2
        {
            get { return Name2; }
            set { Name2 = value; }
        }
    }
}
