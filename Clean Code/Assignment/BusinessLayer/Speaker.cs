using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{

    public class Speaker
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? YearsOfExperience { get; set; }
        public bool HasBlog { get; set; }
        public string BlogURL { get; set; }
        public WebBrowser Browser { get; set; }
        public List<string> Certifications { get; set; }
        public string Employer { get; set; }
        public int RegistrationFee { get; set; }
        public List<BusinessLayer.Session> Sessions { get; set; }


        public int? Register(IRepository repository)
        {
            ValidateRegistration();
            int? speakerId = null;
            speakerId = SaveRepository(repository, speakerId, SessionApprove());
            return speakerId;
        }

        private int? SaveRepository(IRepository repository, int? speakerId, bool IsApproved)
        {
            if (IsApproved)
            {
                try { speakerId = repository.SaveSpeaker(this); }
                catch (Exception e) { }
            }
            else throw new NoSessionsApprovedException("No sessions approved.");
            return speakerId;
        }

        private bool SessionApprove()
        {
            var OldTopics = new List<string>() { "Cobol", "Punch Cards", "Commodore", "VBScript" };
            bool IsApproved = false;
            foreach (var session in Sessions)
            {
                IsApproved = CheckForOldTechnology(IsApproved, session);
            }
            return IsApproved;
        }

        private bool CheckForOldTechnology(bool IsApproved, Session session)
        {
            var OldTopics = new List<string>() { "Cobol", "Punch Cards", "Commodore", "VBScript" };
            foreach (var tech in OldTopics)
            {
                if (session.Title.Contains(tech) || session.Description.Contains(tech))
                {
                    session.Approved = false;
                    throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our abitrary and capricious standards.");
                }
                else
                {
                    session.Approved = true;
                    IsApproved = true;
                }
            }
            return IsApproved;
        }

        private void ValidateRegistration()
        {
            Validate();
            if (!(AppearsExceptional() || !redflag())) throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our abitrary and capricious standards.");

        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(FirstName)) throw new ArgumentNullException("First Name is required");
            if (string.IsNullOrWhiteSpace(LastName)) throw new ArgumentNullException("Last name is required.");
            if (string.IsNullOrWhiteSpace(Email)) throw new ArgumentNullException("Email is required.");
            if (Sessions.Count() == 0) throw new ArgumentException("Can't register speaker with no sessions to present.");
        }

        private bool AppearsExceptional()
        {
            var PreferredEmployers = new List<string>() { "Microsoft", "Google", "Fog Creek Software", "37Signals" };
            if ((YearsOfExperience > 10) || (HasBlog) || (Certifications.Count() > 3) || (PreferredEmployers.Contains(Employer)))
                return true;
            return false;
        }
        private bool redflag()
        {
            var OldDomains = new List<string>() { "aol.com", "hotmail.com", "prodigy.com", "CompuServe.com" };
            string emailDomain = Email.Split('@').Last();
            if (OldDomains.Contains(emailDomain)) return false;
            if (Browser.Name == WebBrowser.BrowserName.InternetExplorer && Browser.MajorVersion < 9) return false;
            return true;
        }

        #region Custom Exceptions
        public class SpeakerDoesntMeetRequirementsException : Exception
        {
            public SpeakerDoesntMeetRequirementsException(string message)
                : base(message)
            {
            }

            public SpeakerDoesntMeetRequirementsException(string format, params object[] args)
                : base(string.Format(format, args))
            { }
        }

        public class NoSessionsApprovedException : Exception
        {
            public NoSessionsApprovedException(string message)
                : base(message)
            {
            }
        }
        #endregion
    }
}