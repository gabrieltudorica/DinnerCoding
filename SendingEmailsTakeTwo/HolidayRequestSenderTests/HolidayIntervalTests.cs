using System;
using HolidayRequestSender;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HolidayRequestSenderTests
{
    [TestClass]
    public class HolidayIntervalTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhenPassingDefaultDateTimeValues_ThrowsException()
        {
            new HolidayInterval(DateTime.MinValue, DateTime.MinValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhenFromDateIsNewerThanToDate_ThrowsException()
        {
            new HolidayInterval(DateTime.Now.AddDays(3), DateTime.Now.AddDays(2));
        }
    }
}
