using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SendingEmails;

namespace SendingEmailsTests
{
    [TestClass]
    public class HolidayRequestEmailTests
    {
        private string _validEmailAddress = "valid@mail.com";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullRequest_ThrowsException()
        {
            var requestSender = new HolidayRequestSender(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyEmployeeName_ThrowsException()
        {
            var request = new HolidayRequest(string.Empty, new MailAddress(_validEmailAddress), new MailAddress(_validEmailAddress), new TimeInterval());
            var requestSender = new HolidayRequestSender(request);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DefaultRequestInterval_ThrowsException()
        {
            var request = new HolidayRequest(string.Empty, new MailAddress(_validEmailAddress), new MailAddress(_validEmailAddress), new TimeInterval());
            var requestSender = new HolidayRequestSender(request);
        }
    }
}
