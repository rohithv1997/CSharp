using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.IDAL
{
    public interface IUser
    {
        bool Login(string LoginName, string Password,out int EmployeeID);
        void RegisterUser(User objUser);
        User ForgotPassword(string LoginName);
        void UpdatePassword(string LoginName, string NewPassword);
        void UpdateSecurityQuestion(User objUser);
    }   
}
