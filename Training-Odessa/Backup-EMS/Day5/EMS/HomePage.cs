using EmployeeLeaveManagement;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.DAL;



namespace EMS
{
    public delegate bool logindelegate(string u, string p, out int eid);
    class HomePage
    {


        static void Main(string[] args)
        {
            try
            {


                // User u1;
                DataSource.PopulateData();
                //Console.SetCursorPosition((Console.WindowWidth - "Welcome".Length) / 2, Console.CursorTop);
                //Console.WriteLine("Welcome");
                Console.SetCursorPosition((Console.WindowWidth - "Employee Management System".Length) / 2, Console.CursorTop);
                Console.WriteLine("Employee Management System");
                Console.ReadKey();
                //Thread.Sleep(2000);

                bool flag = false;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Menu");
                    Console.WriteLine("1.Employee");
                    Console.WriteLine("2.Admin");
                    Console.WriteLine("3.Admin Manager");
                    Console.WriteLine("4.HR");
                    Console.WriteLine("5.Manager");
                    if (flag == false) Console.WriteLine("6.Register New User");
                    Console.WriteLine("99.Exit");
                    Console.WriteLine("Choice: ");
                    int ch;
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            {
                                Employeef();
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            {
                                Adminf();
                                Console.ReadKey();
                                break;
                            }
                        case 3:
                            {
                                AdminManagerf();
                                Console.ReadKey();
                                break;
                            }
                        case 4:
                            {
                                HRf();
                                Console.ReadKey();
                                break;
                            }
                        case 5:
                            {
                                Managerf();
                                Console.ReadKey();
                                break;
                            }
                        case 6:
                            {
                                flag = RegisterUser();
                                if (flag == false) Console.WriteLine("Error! Try Again.");
                                Console.ReadKey();
                                break;
                            }
                        case 99:
                            {
                                Console.WriteLine("Thank You For Using Our System :)");
                                Thread.Sleep(2000);
                                return;
                            }
                        default:
                            {
                                Console.WriteLine("Wrong Choice");
                                break;

                            }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static bool RegisterUser()
        {
            try
            {
                int Id;
                string LoginName, Password, SecurityQuestion, SecurityAnswer;
                //bool IsActive2;
                Console.WriteLine("New User");
                Console.WriteLine("Enter the following details.");
                Console.WriteLine("ID: ");
                Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Login Name: ");
                LoginName = Console.ReadLine();
                Console.WriteLine("Password: ");
                Password = Console.ReadLine();
                Console.WriteLine("Security Question: ");
                SecurityQuestion = Console.ReadLine();
                Console.WriteLine("Security Answer: ");
                SecurityAnswer = Console.ReadLine();
                //IsActive2 = true;
                DataSource.ul.Add(new User { propId = Id, propLoginName = LoginName, propPassword = Password, propSecurityQuestion = SecurityQuestion, propSecurityAnswer = SecurityAnswer, propIsActive2 = true });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
            //throw new NotImplementedException();
        }

        private static void Managerf()
        {
            try
            {
                string u, p;
                int eidf, ch;
                bool status = false, loginn = false;
                ManagerDAL m = new ManagerDAL();
                logindelegate ld = new logindelegate(m.Login);
                Console.WriteLine("Username: ");
                u = Console.ReadLine();
                Console.WriteLine("Password: ");
                p = Console.ReadLine();
                if (ld.Invoke(u, p, out eidf))
                {
                    foreach (var item in DataSource.edl)
                        if (item.propEmployeeId == eidf && item.propRole == EmployeeRole.Manager) loginn = true;
                    if (loginn)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Manager Menu");
                            Console.WriteLine("1.View Leave Requests");
                            Console.WriteLine("2.Approval Status");
                            Console.WriteLine("3.Logout");
                            ch = Convert.ToInt32(Console.ReadLine());
                            switch (ch)
                            {
                                case 1:
                                    {
                                        int leaveid;
                                        status = false;
                                        Console.WriteLine("Search LeaveID:");
                                        leaveid = Convert.ToInt32(Console.ReadLine());
                                        foreach (var it in DataSource.lal)
                                        {
                                            if (it.propLeaveApplicationId == leaveid)
                                            {
                                                foreach (var i in it.propManagerId2)
                                                {
                                                    m.ViewLeaveRequest(i);

                                                }
                                                status = true;
                                                break;
                                            }
                                        }
                                        if (!status) Console.WriteLine("404: Leave Not Found");
                                        break;
                                    }
                                case 2:
                                    {
                                        int leaveid;
                                        status = false;
                                        Console.WriteLine("Search LeaveID:");
                                        leaveid = Convert.ToInt32(Console.ReadLine());
                                        foreach (var it in DataSource.lal)
                                        {
                                            if (it.propLeaveApplicationId == leaveid)
                                            {
                                                m.ApprovalStatus(leaveid, it.propleavestatus);
                                                status = true;
                                                break;
                                            }
                                        }
                                        if (!status) Console.WriteLine("404: Leave Not Found");
                                        break;
                                    }

                                case 3:
                                    {
                                        return;
                                    }
                            }
                            Console.ReadKey();
                        }
                    }
                    else Console.WriteLine("Role mismatch. Try Again. :(");
                }
                else Console.WriteLine("Login Failed. Try Again. :(");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //throw new NotImplementedException();
        }

        private static void HRf()
        {
            try
            {
                 string u, p;
                int eidf;
                
                Admin e = new Admin();
                ManagerDAL m = new ManagerDAL();
                logindelegate ld = new logindelegate(e.Login);
                Console.WriteLine("Username: ");
                u = Console.ReadLine();
                Console.WriteLine("Password: ");
                p = Console.ReadLine();
                if (ld.Invoke(u, p, out eidf))
                {
                    Console.WriteLine("HR Functions");
                }
                else Console.WriteLine("Login Failed. Try Again :(");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //throw new NotImplementedException();
        }

        private static void AdminManagerf()
        {
            try
            {
                string u, p;
                int eidf, ch;
                bool status = false, loginn = false;
                Admin e = new Admin();
                ManagerDAL m = new ManagerDAL();
                logindelegate ld = new logindelegate(e.Login);
                Console.WriteLine("Username: ");
                u = Console.ReadLine();
                Console.WriteLine("Password: ");
                p = Console.ReadLine();
                if (ld.Invoke(u, p, out eidf))
                {
                    foreach (var item in DataSource.edl)
                        if (item.propEmployeeId == eidf && item.propRole == EmployeeRole.Manager) loginn = true;
                    if (loginn)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("AdminManager Menu");
                            Console.WriteLine("1.Add New Employee");
                            Console.WriteLine("2.View All Employee");
                            Console.WriteLine("3.Add New LeaveType");
                            Console.WriteLine("4.View All LeaveTypes");
                            Console.WriteLine("5.Add New Portfoilo");
                            Console.WriteLine("6.Add New Project");
                            Console.WriteLine("7.View Leave Requests");
                            Console.WriteLine("8.Approval Status");
                            Console.WriteLine("9.Logout");
                            Console.WriteLine("Choice: ");
                            ch = Convert.ToInt32(Console.ReadLine());
                            switch (ch)
                            {
                                case 1:
                                    {
                                        int empid;
                                        status = false;
                                        Console.WriteLine("Search EmployeeID: ");
                                        empid = Convert.ToInt32(Console.ReadLine());
                                        foreach (var item in DataSource.edl)
                                        {
                                            if (item.propEmployeeId == empid)
                                            {
                                                e.AddNewEmployee(item);
                                                status = true;
                                                break;
                                            }
                                        }
                                        if (status == false) Console.WriteLine("404. Employee Not Added :(");
                                        break;
                                    }
                                case 2:
                                    {
                                        foreach (var item in DataSource.edl)
                                            e.ViewEmployee(item);
                                        break;
                                    }
                                case 3:
                                    {
                                        int empid;
                                        status = false;
                                        Console.WriteLine("Search LeaveType: ");
                                        empid = Convert.ToInt32(Console.ReadLine());
                                        foreach (var item in DataSource.ltl)
                                        {
                                            if (item.propLeaveTypeId3 == empid)
                                            {
                                                e.AddNewLeaveType(item);
                                                status = true;
                                                break;
                                            }
                                        }
                                        if (status == false) Console.WriteLine("404. LeaveType Not Added :(");
                                        break;
                                    }
                                case 4:
                                    {
                                        foreach (var item in DataSource.ltl)
                                            e.ViewLeaveType(item);
                                        break;
                                    }
                                case 5:
                                    {
                                        int empid;
                                        status = false;
                                        Console.WriteLine("Search PortfolioID: ");
                                        empid = Convert.ToInt32(Console.ReadLine());
                                        foreach (var item in DataSource.pl)
                                        {
                                            if (item.propPortfolioId2 == empid)
                                            {
                                                e.AddPortfolio(item);
                                                status = true;
                                                break;
                                            }
                                        }
                                        if (status == false) Console.WriteLine("404. Portfolio Not Added :(");
                                        break;
                                    }
                                case 6:
                                    {
                                        int empid;
                                        status = false;
                                        Console.WriteLine("Search ProjectID: ");
                                        empid = Convert.ToInt32(Console.ReadLine());
                                        foreach (var item in DataSource.pl2)
                                        {
                                            if (item.propProjectId2 == empid)
                                            {
                                                e.AddNewProject(item);
                                                status = true;
                                                break;
                                            }
                                        }
                                        if (status == false) Console.WriteLine("404. Project Not Added :(");
                                        break;
                                    }
                                case 7:
                                    {
                                        int leaveid;
                                        status = false;
                                        Console.WriteLine("Search LeaveID:");
                                        leaveid = Convert.ToInt32(Console.ReadLine());
                                        foreach (var it in DataSource.lal)
                                        {
                                            if (it.propLeaveApplicationId == leaveid)
                                            {
                                                foreach (var i in it.propManagerId2)
                                                {
                                                    m.ViewLeaveRequest(i);

                                                }
                                                status = true;
                                                break;
                                            }
                                        }
                                        if (!status) Console.WriteLine("404: Leave Not Found");
                                        break;
                                    }
                                case 8:
                                    {
                                        int leaveid;
                                        status = false;
                                        Console.WriteLine("Search LeaveID:");
                                        leaveid = Convert.ToInt32(Console.ReadLine());
                                        foreach (var it in DataSource.lal)
                                        {
                                            if (it.propLeaveApplicationId == leaveid)
                                            {
                                                m.ApprovalStatus(leaveid, it.propleavestatus);
                                                status = true;
                                                break;
                                            }
                                        }
                                        if (!status) Console.WriteLine("404: Leave Not Found");
                                        break;
                                    }
                                case 9:
                                    {
                                        return;
                                    }
                            }
                            Console.ReadKey();
                        }
                    }
                    else Console.WriteLine("Role mismatch. Try Again :(");
                }
                else Console.WriteLine("Login Failed. Try Again :(");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            // throw new NotImplementedException();
        }

        private static void Adminf()
        {
            try
            {
                string u, p;
                int eidf, ch;
                bool status = false, loginn = false;
                Admin e = new Admin();
                logindelegate ld = new logindelegate(e.Login);
                Console.WriteLine("Username: ");
                u = Console.ReadLine();
                Console.WriteLine("Password: ");
                p = Console.ReadLine();
                if (ld.Invoke(u, p, out eidf))
                {
                    foreach (var item in DataSource.edl)
                        if (item.propEmployeeId == eidf && item.propRole == EmployeeRole.Manager) loginn = true;
                    if (loginn)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Admin Menu");
                            Console.WriteLine("1.Add New Employee");
                            Console.WriteLine("2.View All Employee");
                            Console.WriteLine("3.Add New LeaveType");
                            Console.WriteLine("4.View All LeaveTypes");
                            Console.WriteLine("5.Add New Portfoilo");
                            Console.WriteLine("6.Add New Project");
                            Console.WriteLine("7.Logout");
                            Console.WriteLine("Choice: ");
                            ch = Convert.ToInt32(Console.ReadLine());
                            switch (ch)
                            {
                                case 1:
                                    {
                                        int empid;
                                        status = false;
                                        Console.WriteLine("Search EmployeeID: ");
                                        empid = Convert.ToInt32(Console.ReadLine());
                                        foreach (var item in DataSource.edl)
                                        {
                                            if (item.propEmployeeId == empid)
                                            {
                                                e.AddNewEmployee(item);
                                                status = true;
                                                break;
                                            }
                                        }
                                        if (status == false) Console.WriteLine("404. Employee Not Added :(");
                                        break;
                                    }
                                case 2:
                                    {
                                        foreach (var item in DataSource.edl)
                                            e.ViewEmployee(item);
                                        break;
                                    }
                                case 3:
                                    {
                                        int empid;
                                        status = false;
                                        Console.WriteLine("Search LeaveType: ");
                                        empid = Convert.ToInt32(Console.ReadLine());
                                        foreach (var item in DataSource.ltl)
                                        {
                                            if (item.propLeaveTypeId3 == empid)
                                            {
                                                e.AddNewLeaveType(item);
                                                status = true;
                                                break;
                                            }
                                        }
                                        if (status == false) Console.WriteLine("404. LeaveType Not Added :(");
                                        break;
                                    }
                                case 4:
                                    {
                                        foreach (var item in DataSource.ltl)
                                            e.ViewLeaveType(item);
                                        break;
                                    }
                                case 5:
                                    {
                                        int empid;
                                        status = false;
                                        Console.WriteLine("Search PortfolioID: ");
                                        empid = Convert.ToInt32(Console.ReadLine());
                                        foreach (var item in DataSource.pl)
                                        {
                                            if (item.propPortfolioId2 == empid)
                                            {
                                                e.AddPortfolio(item);
                                                status = true;
                                                break;
                                            }
                                        }
                                        if (status == false) Console.WriteLine("404. Portfolio Not Added :(");
                                        break;
                                    }
                                case 6:
                                    {
                                        int empid;
                                        status = false;
                                        Console.WriteLine("Search ProjectID: ");
                                        empid = Convert.ToInt32(Console.ReadLine());
                                        foreach (var item in DataSource.pl2)
                                        {
                                            if (item.propProjectId2 == empid)
                                            {
                                                e.AddNewProject(item);
                                                status = true;
                                                break;
                                            }
                                        }
                                        if (status == false) Console.WriteLine("404. Project Not Added :(");
                                        break;
                                    }
                                case 7:
                                    {
                                        return;
                                    }
                            }
                            Console.ReadKey();
                        }
                    }
                    else Console.WriteLine("Role mismatch. Try Again. :(");
                }
                else Console.WriteLine("Login Failed. Try Again. :(");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //throw new NotImplementedException();
        }

        private static void Employeef()
        {
            try
            {
                string u, p;
                int eidf, ch;
                bool status = false;
                EmployeeDAL e = new EmployeeDAL();
                logindelegate ld = new logindelegate(e.Login);
                Console.WriteLine("Username: ");
                u = Console.ReadLine();
                Console.WriteLine("Password: ");
                p = Console.ReadLine();
                if (ld.Invoke(u, p, out eidf))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Employee Menu");
                        Console.WriteLine("1.Apply Leave");
                        Console.WriteLine("2.Leave Application Status");
                        Console.WriteLine("3.Cancel Leave Application");
                        Console.WriteLine("4.View Leave History");
                        Console.WriteLine("5.View Leave Availablity");
                        Console.WriteLine("6.Logout");
                        Console.WriteLine("Choice: ");
                        ch = Convert.ToInt32(Console.ReadLine());
                        switch (ch)
                        {
                            case 1:
                                {
                                    for (int i = 0; i < DataSource.lal.Count && status == false; i++)
                                    {
                                        if (DataSource.lal[i].propEmployeeId3 == eidf)
                                        {
                                            e.ApplyLeave(DataSource.lal[i]);
                                            status = true;
                                            //break;
                                        }
                                    }
                                    if (status == false) Console.WriteLine("404: Leave Not Applied :(");
                                    break;
                                }
                            case 2:
                                {
                                    int leaveid;
                                    status = false;
                                    Console.WriteLine("Search Leave Application ID: ");
                                    leaveid = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < DataSource.lal.Count && status == false; i++)
                                    {
                                        if (DataSource.lal[i].propEmployeeId3 == eidf && DataSource.lal[i].propLeaveApplicationId == leaveid)
                                        {
                                            status = true;
                                            e.ViewCurrentLeaveStatus(DataSource.lal[i].propleavestatus);
                                            //break;
                                        }
                                    }
                                    if (status == false) Console.WriteLine("404: Leave Not Found :(");
                                    break;
                                }
                            case 3:
                                {
                                    int leaveid;
                                    status = false;
                                    Console.WriteLine("Search Leave Application ID: ");
                                    leaveid = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < DataSource.lal.Count && status == false; i++)
                                    {
                                        if (DataSource.lal[i].propEmployeeId3 == eidf && DataSource.lal[i].propLeaveApplicationId == leaveid)
                                        {
                                            status = true;
                                            e.CancelLeave(leaveid);
                                            //break;
                                        }
                                    }
                                    if (status == false) Console.WriteLine("404: Leave Not Found :(");
                                    break;
                                }
                            case 4:
                                {
                                    //int leaveid;
                                    status = false;
                                    //Console.WriteLine("Search Leave Application ID: ");
                                    // leaveid = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < DataSource.lal.Count && status == false; i++)
                                    {
                                        if (DataSource.lal[i].propEmployeeId3 == eidf)
                                        {
                                            status = true;
                                            e.ViewLeaveHistory(eidf, DataSource.lal[i].propLeaveTypeId);
                                            //break;
                                        }
                                    }
                                    if (status == false) Console.WriteLine("404: Leave Not Taken :(");
                                    break;
                                }
                            case 5:
                                {
                                    //int leaveid;
                                    status = false;
                                    //Console.WriteLine("Search Leave Application ID: ");
                                    // leaveid = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < DataSource.lal.Count && status == false; i++)
                                    {
                                        if (DataSource.lal[i].propEmployeeId3 == eidf)
                                        {
                                            status = true;
                                            e.ViewLeaveAvailability(eidf);
                                            //break;
                                        }
                                    }
                                    if (status == false) Console.WriteLine("404: Leave Not Found :(");
                                    break;
                                }
                            case 6:
                                {
                                    return;
                                }

                        }
                        Console.ReadKey();
                    }
                }
                else Console.WriteLine("Login Failed. Try Again.");
                //throw new NotImplementedException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}