using System;
using System.Net.Mail;

namespace SendingEmails
{
    public class Employee
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly IEmployeeConfiguration _config;

        public Employee(string firstName, string lastName, IEmployeeConfiguration config)
        {
            _firstName = firstName;
            _lastName = lastName;
            _config = config;

            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(_firstName) || string.IsNullOrEmpty(_lastName))
            {
                throw new ArgumentException("First and last name cannot be null");
            }
        }

        public string EmployeeName 
        {
            get { return string.Format("{0} {1}", _firstName, _lastName); }
        }

        public MailAddress GetEmployeeEmail()
        {
            return new MailAddress(string.Format("{0}.{1}@{2}", _firstName, _lastName, _config.CompanyHost));
        }
    }
}
