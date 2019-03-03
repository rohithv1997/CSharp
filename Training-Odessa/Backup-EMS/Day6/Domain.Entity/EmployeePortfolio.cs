using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class EmployeePortfolio
    {
        int EmployeeId2;
        public int propEmployeeId2
        {
            get { return EmployeeId2; }
            set { EmployeeId2 = value; }
        }
        int ProjectId;
        public int propProjectId
        {
            get { return ProjectId; }
            set { ProjectId = value; }
        }
        int PortfolioId;
        public int propPortfolioId
        {
            get { return PortfolioId; }
            set { PortfolioId = value; }
        }
    }
}
