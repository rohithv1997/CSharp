using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public enum EmployeeLevel
    {
        L1, L2, L3A, L3B, L4A, L4B, L4C, L5A, L5B, L5C, L6A, L6B, L6C, L7
    }

    public enum EmployeeRole
    {
        Admin, AdminManager, Manager, Employee, HumanResource, Finance

    }


    public class EmployeeDetails
    {
        int EmployeeId;
        public int propEmployeeId
        {
            get { return EmployeeId; }
            set { EmployeeId = value; }
        }
        string FirstName;
        public string propFirstName
        {
            get { return FirstName; }
            set { FirstName = value; }
        }
        string LastName;
        public string propLastName
        {
            get { return LastName; }
            set { LastName = value; }
        }
        string Email;
        public string propEmail
        {
            get { return Email; }
            set { Email = value; }
        }
        string Mobile;
        public string propMobile
        {
            get { return Mobile; }
            set { Mobile = value; }
        }
        DateTime DateOfJoin;
        public DateTime propDateOfJoin
        {
            get { return DateOfJoin; }
            set { DateOfJoin = value; }
        }
        string Gender;
        public string propGender
        {
            get { return Gender; }
            set { Gender = value; }
        }
        bool IsActive;
        public bool propIsActive
        {
            get { return IsActive; }
            set { IsActive = value; }
        }
        int DepartmentId;
        public int propDeparmentId
        {
            get { return DepartmentId; }
            set { DepartmentId = value; }
        }
        int ReportingTo;
        public int propReportingTo
        {
            get { return ReportingTo; }
            set { ReportingTo = value; }
        }
        int PortfolioManagerId;
        public int propPortfolioManagerId
        {
            get { return PortfolioManagerId; }
            set { PortfolioManagerId = value; }
        }

        EmployeeRole Role;
        public EmployeeRole propRole
        {
            get { return Role; }
            set { Role = value; }
        }

        EmployeeLevel employeelevel;
        public EmployeeLevel propEmployeeLevel
        {
            get { return employeelevel; }
            set { employeelevel = value; }
        }
    }
}
