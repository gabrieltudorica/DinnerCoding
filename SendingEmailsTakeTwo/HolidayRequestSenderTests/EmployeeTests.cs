using System;
using HolidayRequestSender;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HolidayRequestSenderTests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhenPassingEmptyStringParameters_ThrowsException()
        {
            new Employee(string.Empty, string.Empty);
        }

        [TestMethod]
        public void GetFullName_WhenParamsAreValid_ReturnsFirstAndLastName()
        {
            var employee = new Employee("Nucky", "Thompson");
            Assert.AreEqual("Nucky Thompson", employee.GetFullName());
        }

        [TestMethod]
        public void GetEmail_WhenParamsAreValid_ReturnsFirstDotLastNameAtCompanyHost()
        {
            var employee = new Employee("Nucky", "Thompson");
            Assert.AreEqual("nucky.thompson@company.com", employee.GetEmail());
        }
    }
}
