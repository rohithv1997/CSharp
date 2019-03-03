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
    class AdminManager: EmployeeDetails, IAdmin, IProject, IManager
    {
        public void AddNewEmployee(Domain.Entity.EmployeeDetails objEmp)
        {
            throw new NotImplementedException();
        }

        public void AddNewLeaveType(LeaveType objLeaveType)
        {
            throw new NotImplementedException();
        }

        public void AddPortfolio(Portfolio objPortfolio)
        {
            throw new NotImplementedException();
        }

        public void AdjustLeave(LeaveAvailablity objLeaveAvailability)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Domain.Entity.EmployeeDetails objEmp)
        {
            throw new NotImplementedException();
        }

        public void UpdateHoliday(Holiday objHoliday)
        {
            throw new NotImplementedException();
        }

        public void UpdateLeaveType(LeaveType objLeaveType)
        {
            throw new NotImplementedException();
        }

        public void AddNewProject(Project objProject)
        {
            throw new NotImplementedException();
        }

        public void UpdateProject(Project objProject)
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
    }
}
