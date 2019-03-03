using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.IDAL
{
    public interface IPortfolioHr
    {
        void AddEmployeeToPortfolio(EmployeePortfolio objEmpPortfolio);
        void UpdateEmployeePortfolio(EmployeePortfolio objEmpPortfolio);
    }
}
