using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class User
    {
        int Id;
        public int propId
        {
            get { return Id; }
            set { Id = value; }
        }
        string LoginName;
        public string propLoginName
        {
            get { return LoginName; }
            set { LoginName = value; }
        }
        string Password;
        public string propPassword
        {
            get { return Password; }
            set { Password = value; }
        }
        string SecurityQuestion;
        public string propSecurityQuestion
        {
            get { return SecurityQuestion; }
            set { SecurityQuestion = value; }
        }
        string SecurityAnswer;
        public string propSecurityAnswer
        {
            get { return SecurityAnswer; }
            set { SecurityAnswer = value; }
        }
        bool IsActive2;
        public bool propIsActive2
        {
            get { return IsActive2; }
            set { IsActive2 = value; }
        }
    }
}
