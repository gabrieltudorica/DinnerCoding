using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SendingEmails;
using System;

namespace SendingEmailsTests
{
    [TestClass]
    public class HolidayRequestSenderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullRequest_ThrowsException()
        {
            var requestSender = new HolidayRequestSender(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DefaultRequestInterval_ThrowsException()
        {
            var employeeConfigMock = new Mock<IEmployeeConfiguration>();
            employeeConfigMock.Setup(m => m.CompanyHost).Returns("someHost.com");

            var employee = new Employee("firstName", "lastName", employeeConfigMock.Object);
            
            var request = new HolidayRequest(employee, employee, new TimeInterval());
            var requestSender = new HolidayRequestSender(request);
        }
    }
}
