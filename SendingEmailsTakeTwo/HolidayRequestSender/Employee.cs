using System;

namespace HolidayRequestSender
{
    public class Employee
    {
        private readonly string _firstName;
        private readonly string _lastName;

        public Employee(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(_firstName) || string.IsNullOrEmpty(_lastName))
            {
                throw new ArgumentException("firstName cannot be null or empty");
            }
        }

        public string GetFullName()
        {
            return _firstName + " " + _lastName;
        }
    }
}
