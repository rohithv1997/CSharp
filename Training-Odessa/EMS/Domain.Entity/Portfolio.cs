using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Portfolio
    {
        int PortfolioId2;
        public int propPortfolioId2
        {
            get { return PortfolioId2; }
            set { PortfolioId2 = value; }
        }
        int ManagerId3;
        public int propManagerID3
        {
            get { return ManagerId3; }
            set { ManagerId3 = value; }
        }
        int HrId;
        public int propHrId
        {
            get { return HrId; }
            set { HrId = value; }
        }
        bool IsActive3;
        public bool propIsActive3
        {
            get { return IsActive3; }
            set { IsActive3 = value; }
        }

    }
}
