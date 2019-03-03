using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
namespace EMS
{
    static class DataSource
    {
        public static List<Department> dl;
        public static List<EmployeeDetails> edl;
        public static List<EmployeePortfolio> epl;
        public static List<LeaveApplication> lal;
        public static List<LeaveAvailablity> lal2;
        public static List<LeaveType> ltl;
        public static List<LeaveValidation> lvl;
        public static List<Manager> ml;
        public static List<Portfolio> pl;
        public static List<Project> pl2;
        public static List<User> ul;

        static public void PopulateData()
        {
            dl = new List<Department>
            {   new Department() { propDepartmentId2=1, propName2 = "HR" },
                new Department() { propDepartmentId2=2, propName2 = "Finance" }
            };
            edl = new List<EmployeeDetails>
            {
                new EmployeeDetails() { propEmployeeId=1,propFirstName="Don",propLastName="Jose",propEmail="don.j@odessainc.com",propMobile="+91 1234567890",
                    propDateOfJoin =new DateTime(2017,12,01),propGender="Male",propIsActive=true, propDeparmentId=1,propReportingTo=2,propPortfolioManagerId=100,propRole=EmployeeRole.Employee,propEmployeeLevel=EmployeeLevel.L1 },
                 new EmployeeDetails() { propEmployeeId=2,propFirstName="Pablo",propLastName="Escobar",propEmail="pablo.e@odessainc.com",propMobile="+91 9876543210",
                    propDateOfJoin =new DateTime(2017,11,01),propGender="Male",propIsActive=true, propDeparmentId=1,propReportingTo=0,propPortfolioManagerId=101,propRole=EmployeeRole.Manager,propEmployeeLevel=EmployeeLevel.L2 }
            };
            epl = new List<EmployeePortfolio>
            {   new EmployeePortfolio() { propEmployeeId2=1,propProjectId=1001,propPortfolioId=102 },
                new EmployeePortfolio() {propEmployeeId2=2,propProjectId=1001,propPortfolioId=103 }
            };
            lal = new List<LeaveApplication>
            {
                new LeaveApplication() { propLeaveApplicationId=12,propEmployeeId3=4,propLeaveTypeId=1,propStartDate=new DateTime(2017,11,01),propEndDate=new DateTime(2017,11,11),propAppliedDate=new DateTime(2017,10,20),propLeaveDay=Leavetype.Fullday,propLeaveReason="Casual Leave",propManagerId2=new List<int> {100,99,88,77 },propAlternateContactId="+91 9876987698",propleavestatus=LeaveStatus.Approve,propNoOfDays3=10 },
                new LeaveApplication() { propLeaveApplicationId=13,propEmployeeId3=5,propLeaveTypeId=2,propStartDate=new DateTime(2017,11,01),propEndDate=new DateTime(2017,21,11),propAppliedDate=new DateTime(2017,10,30),propLeaveDay=Leavetype.HalfDayFirstHalf,propLeaveReason="Sick Leave",propManagerId2=new List<int> {101,98,87,76 },propAlternateContactId="+91 9879879879",propleavestatus=LeaveStatus.Approve,propNoOfDays3=20 }
            };
            lal2 = new List<LeaveAvailablity>
            {
                new LeaveAvailablity() {propLeaveTypeId2=12,propEmployeeId3=1,propCarry=100,propYear=new DateTime(2017,10,20),propAvailableLeave=10,propAvailedLeave=5 },
                new LeaveAvailablity() {propLeaveTypeId2=13,propEmployeeId3=2,propCarry=110,propYear=new DateTime(2017,11,30),propAvailableLeave=20,propAvailedLeave=15  }
            };
            ltl = new List<LeaveType>()
            {
                new LeaveType() {propLeaveTypeId3=12,propName3="Casual Leave",propMaxNoOfDays=10,propContinuousDays=5,propDaysInAdvance=3 },
                new LeaveType() {propLeaveTypeId3=13,propName3="Emergency Leave",propMaxNoOfDays=11,propContinuousDays=6,propDaysInAdvance=2 }
            };
            lvl = new List<LeaveValidation>
            {
                new LeaveValidation() {propEmployeeId4=1,propLeaveTypeId4=12,propContinuousDays2=4,propDaysInAdvance2=5,propAvailableLeave2=5,propAvailedLeave2=6 },
                new LeaveValidation() {propEmployeeId4=2,propLeaveTypeId4=13,propContinuousDays2=6,propDaysInAdvance2=3,propAvailableLeave2=4,propAvailedLeave2=5 }
            };
            ml = new List<Manager>
            {
                new Manager() {propManagerId=2,propName="Pablo" },
                new Manager() {propManagerId=4,propName="Steve" }
            };
            pl = new List<Portfolio>
            {
                new Portfolio() {propPortfolioId2=102,propIsActive3=true,propHrId=1221,propManagerID3=2 },
                new Portfolio() {propPortfolioId2=103,propIsActive3=true,propHrId=2112,propManagerID3=4 }
            };
            pl2 = new List<Project>
            {
                new Project() {propProjectId2=1001,propName4="PNC Bank",propIsActive4=true,propManagerId4=2,propPortfolioId3=101 },
                new Project() { propProjectId2=1002,propName4="GE",propIsActive4=true,propManagerId4=4,propPortfolioId3=102}
            };
            ul = new List<User>
            {
                new User() {propId=111,propLoginName="tonystark",propPassword="ironman",propIsActive2=true,propSecurityQuestion="Who am I?",propSecurityAnswer="Playboy" },
                new User() {propId=222,propLoginName="brucewayne",propPassword="batman",propIsActive2=true,propSecurityQuestion="What am I?",propSecurityAnswer="Billionaire" }
            };
        }
    }
}