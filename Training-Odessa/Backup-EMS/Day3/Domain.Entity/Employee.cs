using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    enum EmployeeRole { };
    enum EmployeeLevel { };
    class Employee
    {
        int EmployeeId;
        public int propEmployeeId { get; set; }
        string FirstName;
        public string propFirstName { get; set; }
        string LastName;
        public string propLastName { get; set; }
        string Email;
        public string propEmail { get; set; }
        string Mobile;
        public string propMobile { get; set; }
        DateTime DateOfJoin;
        public DateTime propDateOfJoin { get; set; }
        string Gender;
        public string propGender { get; set; }
        bool IsActive;
        public bool propIsActive { get; set; }
        int DepartmemtId;
        public int propDeparmentId { get; set; }
        int ReportingTo;
        public int propReportingTo { get; set; }
        int PortfolioManagerId;
        public int propPortfolioManagerId { get; set; }

        EmployeeRole Role;

        EmployeeLevel employeelevel;
    }
    class Manager
    {
        int ManagerId;
        public int propManagerId { get; set; }
        string Name;
        public string propName { get; set; }
    }
    class User
    {
        int Id;
        public int propId { get; set; }
        string LoginName;
        public string propLoginName { get; set; }
        string Password;
        public string propPassword { get; set; }
        string SecurityQuestion;
        public string propSecurityQuestion { get; set; }
        string SecurityAnswer;
        public string propSecurityAnswer { get; set; }
        bool IsActive;
        public bool propIsActive2 { get; set; }
    }
    class Department
    {
        int DepartmentId;
        public int propDepartmentId2 { get; set; }
        string Name;
        public int propName2 { get; set; }
    }
    class EmployeePortfolio
    {
        int EmployeeId2;
        public int propEmployeeId2 { get; set; }
        int ProjectId;
        public int propProjectId { get; set; }
        int PortfolioId;
        public int propPortfolioId { get; set; }
    }
    enum Leavetype { };
    enum LeaveStatus { };
    class LeaveApplication
    {
        int LeaveAppliactionId;
        public int propLeaveApplicationId { get; set; }
        int EmployeeId;
        public int propEmployeeId3 { get; set; }
        int LeaveTypeId;
        public int propLeaveTypeId { get; set; }
        DateTime StartDate;
        public DateTime propStartDate { get; set; }
        DateTime EndDate;
        public DateTime propEndDate { get; set; }
        DateTime AppliedDate;
        public DateTime propAppliedDate { get; set; }
        Leavetype LeaveDay;
        string LeaveReason;
        public string propLeaveReason { get; set; }
        LeaveStatus leavestatus;
        string AlternateContactId;
        public string propAlternateContactId { get; set; }
        List<int> ManagerId = new List<int>();
        public List<int> propManagerId2 { get; set; }

    }
    class LeaveAvailablity
    {
        int LeaveTypeId;
        public int propLeaveTypeId2 { get; set; }
        int EmployeeId;
        public int propEmployeeId3 { get; set; }
        decimal Carry;
        public decimal propCarry { get; set; }
        DateTime Year;
        public DateTime propYear { get; set; }
        decimal AvailedLeave;
        public decimal propAvailedLeave { get; set; }
        decimal AvailableLeave;
        public decimal propAvailableLeave { get; set; }
    }
    class LeaveType
    {
        int LeaveTypeId;
        public int propLeaveTypeId3 { get; set; }
        string Name;
        public string propName3 { get; set; }
        decimal MaxNoOfDays;
        public decimal propMaxNoOfDays { get; set; }
        decimal ContinuousDays;
        public decimal propContinuousDays { get; set; }
        decimal DaysInAdvance;
        public decimal propDaysInAdvance { get; set; }
    }
    class LeaveValidation
    {
        int EmployeeId;
        public int propEmployeeId4 { get; set; }
        int LeaveTypeId;
        public int propLeaveTypeId4 { get; set; }
        decimal ContinuousDays;
        public decimal propContinuousDays2 { get; set; }
        decimal DaysInAdvance;
        public decimal propDaysInAdvance2 { get; set; }
        decimal AvailedLeave;
        public decimal propAvailedLeave2 { get; set; }
        decimal AvailableLeave;
        public decimal propAvailableLeave2 { get; set; }
    }
    class Portfolio
    {
        int PortfolioId;
        public int propPortfolioId2 { get; set; }
        int ManagerId;
        public int propManagerID3 { get; set; }
        int HrId;
        public int propHrId { get; set; }
        bool IsActive;
        public bool propIsActive3 { get; set; }

    }
    class Project
    {
        int ProjectId;
        public int propProjectId2 { get; set; }
        int Name;
        public  int propName4 { get; set; }
        int ManagerId;
        public int propManagerId4 { get; set; }
        int PortfolioId;
        public int propPortfolioId3 { get; set; }
        bool IsActive;
        public bool propIsActive4 { get; set; }
    }
}
