using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IDAL;
using Domain.Entity;
namespace Domain.DAL
{
    public class Admin:EmployeeDAL,IAdmin
    {
        public void AddNewEmployee(EmployeeDetails objEmp)
        {
            Console.WriteLine("Employee added successfully");
           // throw new NotImplementedException();
        }

        public void AddNewLeaveType(LeaveType objLeaveType)
        {
            Console.WriteLine("Leave Type added successfully");
           // throw new NotImplementedException();
        }

        public void AddPortfolio(Portfolio objPortfolio)
        {
            Console.WriteLine("Portfolio added successfully");
            //throw new NotImplementedException();
        }

        public void AdjustLeave(LeaveAvailablity objLeaveAvailability)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(EmployeeDetails objEmp)
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
            Console.WriteLine("Project added successfully");
            //throw new NotImplementedException();
        }

        public void UpdateProject(Project objProject)
        {
            throw new NotImplementedException();
        }

        public void ViewEmployee(EmployeeDetails obj)
        {
            Console.WriteLine("EmployeeID :" + obj.propEmployeeId);
            Console.WriteLine("FirstName :" + obj.propFirstName);
            Console.WriteLine("Role :" + obj.propRole);
            Console.WriteLine("DateOfJoin :" + obj.propDateOfJoin);
            Console.WriteLine("Email :" + obj.propEmail);
            Console.WriteLine("DepartmentId :" + obj.propDeparmentId);
            Console.WriteLine("Gender :" + obj.propGender);
            Console.ReadKey();
            //throw new NotImplementedException();
        }

        public void ViewLeaveType(LeaveType obj)
        {
            Console.WriteLine(" Name " + obj.propName3);
            Console.WriteLine("LeaveTypeId " + obj.propLeaveTypeId3);
            Console.WriteLine("MaxNoOfDays " + obj.propMaxNoOfDays);
            Console.WriteLine("DaysInAdvance " + obj.propDaysInAdvance);
            Console.WriteLine("ContinuesDays " + obj.propContinuousDays);
            //throw new NotImplementedException();
        }
    }
}
