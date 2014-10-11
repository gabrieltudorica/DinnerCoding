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
        public void GetFullName_FirstAndLastNameValid_ReturnsFullName()
        {
            var employee = new Employee("Nucky", "Thompson");
            Assert.AreEqual("Nucky Thompson", employee.GetFullName());
        }
    }
}
