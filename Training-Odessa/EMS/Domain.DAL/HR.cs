using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.IDAL;

namespace Domain.DAL
{
    class HR : EmployeeDetails, IProject, IPortfolioHr, IManager
    {
        public void AddNewProject(Project objProject)
        {
            throw new NotImplementedException();
        }

        public void UpdateProject(Project objProject)
        {
            throw new NotImplementedException();
        }



        public void AddEmployeeToPortfolio(EmployeePortfolio objEmpPortfolio)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployeePortfolio(EmployeePortfolio objEmpPortfolio)
        {
            throw new NotImplementedException();
        }

        public void ApprovalStatus(int LeaveID,LeaveStatus status)
        {
            throw new NotImplementedException();
        }

        public void ViewLeaveRequest(int ManagerID)
        {
            throw new NotImplementedException();
        }

        void IProject.AddNewProject(Project objProject)
        {
            throw new NotImplementedException();
        }

        void IProject.UpdateProject(Project objProject)
        {
            throw new NotImplementedException();
        }
    }
}
