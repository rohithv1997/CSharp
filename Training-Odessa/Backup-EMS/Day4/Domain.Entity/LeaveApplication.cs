using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public enum Leavetype { Fullday, HalfDayFirstHalf, HalfDaySecondHalf }
    public enum LeaveStatus { Approve, Rejected, Cancelled, Pending }
    public class LeaveApplication
    {
        int LeaveApplicationId;
        public int propLeaveApplicationId
        {
            get { return LeaveApplicationId; }
            set { LeaveApplicationId = value; }
        }
        int EmployeeId3;
        public int propEmployeeId3
        {
            get { return EmployeeId3; }
            set { EmployeeId3 = value; }
        }
        int LeaveTypeId;
        public int propLeaveTypeId
        {
            get { return LeaveTypeId; }
            set { LeaveTypeId = value; }
        }
        DateTime StartDate;
        public DateTime propStartDate
        {
            get { return StartDate; }
            set { StartDate = value; }
        }
        DateTime EndDate;
        public DateTime propEndDate
        {
            get { return EndDate; }
            set { EndDate = value; }
        }
        DateTime AppliedDate;
        public DateTime propAppliedDate
        {
            get { return AppliedDate; }
            set { AppliedDate = value; }
        }
        Leavetype LeaveDay;
        public Leavetype propLeaveDay
        {
            get { return LeaveDay; }
            set { LeaveDay = value; }

        }
        string LeaveReason;
        public string propLeaveReason
        {
            get { return LeaveReason; }
            set { LeaveReason = value; }
        }
        LeaveStatus leavestatus;
        public LeaveStatus propleavestatus
        {
            get { return leavestatus;}
            set { leavestatus = value; }
        }
        string AlternateContactId;
        public string propAlternateContactId
        {
            get { return AlternateContactId; }
            set { AlternateContactId = value; }
        }
        List<int> ManagerId = new List<int>();
        public List<int> propManagerId2
        {
            get { return ManagerId; }
            set { if (value != null) ManagerId.AddRange(value); }
        }
        decimal NoOfDays3;
        public decimal propNoOfDays3
        {
            get { return NoOfDays3; }
            set { NoOfDays3 = value; }
        }

    }
}
