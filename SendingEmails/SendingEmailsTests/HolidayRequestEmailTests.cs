using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SendingEmails;

namespace SendingEmailsTests
{
    [TestClass]
    public class HolidayRequestEmailTests
    {
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
            var request = new HolidayRequest(string.Empty, string.Empty, string.Empty, DateTime.MinValue, DateTime.MaxValue);
            var requestSender = new HolidayRequestSender(request);
        }
    }
}
