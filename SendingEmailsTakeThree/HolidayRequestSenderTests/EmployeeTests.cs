using System.Configuration;
using System.Net.Mail;
using HolidayRequestSender;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HolidayRequestSenderTests
{
    [TestClass]
    public class EmployeeTests
    {
        private const string FirstName = "Nucky";
        private const string LastName = "Thompson";

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhenPassingEmptyStringParameters_ThrowsException()
        {
            new Employee(string.Empty, string.Empty);
        }

        [TestMethod]
        public void GetFullName_WhenParamsAreValid_ReturnsFirstAndLastName()
        {            
            Assert.AreEqual(FirstName + " " + LastName, GetEmployee().GetFullName());
        }

        [TestMethod]
        public void GetEmail_WhenParamsAreValid_ReturnsFirstDotLastNameAtCompanyHost()
        {
            var employee = GetEmployee();
            string emailAddress = string.Format("{0}.{1}@{2}",
                FirstName, LastName,
                ConfigurationManager.AppSettings["companyHost"]);

            var expectedMailAddress = new MailAddress(emailAddress, FirstName + " " + LastName);

            Assert.AreEqual(expectedMailAddress, employee.GetEmail());
        }

        private static Employee GetEmployee()
        {
            return new Employee(FirstName, LastName);
        }
    }
}
