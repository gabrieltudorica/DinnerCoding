using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SendingEmails;
using System;

namespace SendingEmailsTests
{
    [TestClass]
    public class HolidayRequestComposerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullRequest_ThrowsException()
        {
            new HolidayRequestComposer(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DefaultRequestInterval_ThrowsException()
        {
            var employee = GetEmployee();
            
            var request = new HolidayRequest(employee, employee, new TimeInterval());
            new HolidayRequestComposer(request);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToIntervalEqualToFromDate_ThrowsException()
        {
            var now = DateTime.Now;
            var employee = GetEmployee();            

            var request = new HolidayRequest(employee, employee, new TimeInterval{From = now, To = now});
            new HolidayRequestComposer(request);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToIntervalLowerThanFromDate_ThrowsException()
        {
            var now = DateTime.Now;
            var employee = GetEmployee();

            var request = new HolidayRequest(employee, employee, new TimeInterval { From = now, To = now.AddDays(-1) });
            new HolidayRequestComposer(request);
        }

        [TestMethod]
        public void RequestSentToManager_IsCorrect()
        {

        }

        private Employee GetEmployee()
        {
            var employeeConfigMock = new Mock<IEmployeeConfiguration>();
            employeeConfigMock.Setup(m => m.CompanyHost).Returns("someHost.com");

            return new Employee("firstName", "lastName", employeeConfigMock.Object);
        }
    }
}
