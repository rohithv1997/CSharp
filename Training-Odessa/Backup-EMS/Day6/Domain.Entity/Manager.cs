using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Manager
    {
        int ManagerId;
        public int propManagerId {
            get { return ManagerId; }
            set { ManagerId = value; }
        }
        string Name;
        public string propName {
            get { return Name; }
            set { Name = value; }
        }
    }
}
