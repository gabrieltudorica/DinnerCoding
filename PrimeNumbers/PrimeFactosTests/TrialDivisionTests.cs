using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeNumbers;

namespace PrimeFactosTests
{
    [TestClass]
    public class TrialDivisionTests
    {
        [TestMethod]
        public void TrialDivisionMethod_ChecksIfOneIsPrime_ReturnsFalse()
        {
            Assert.IsFalse(TrialDivision.IsPrime(1));
        }

        [TestMethod]
        public void TrialDivisionMethod_ChecksIfTwoIsPrime_ReturnsTrue()
        {
            Assert.IsTrue(TrialDivision.IsPrime(2));
        }

        [TestMethod]
        public void TrialDivisionMethod_ChecksIfThreeIsPrime_ReturnsTrue()
        {
            Assert.IsTrue(TrialDivision.IsPrime(3));
        }

        [TestMethod]
        public void TrialDivisionMethod_ChecksIfFourIsPrime_ReturnsFalse()
        {
            Assert.IsFalse(TrialDivision.IsPrime(4));
        }

        [TestMethod]
        public void TrialDivisionMethod_ChecksIfFiveIsPrime_ReturnsTrue()
        {
            Assert.IsTrue(TrialDivision.IsPrime(5));
        }

        [TestMethod]
        public void TrialDivisionMethod_ChecksIfSixIsPrime_ReturnsFalse()
        {
            Assert.IsFalse(TrialDivision.IsPrime(6));
        }

        [TestMethod]
        public void TrialDivisionMethod_ChecksRandomPrimeNumber_ReturnsTrue()
        {
            Assert.IsTrue(TrialDivision.IsPrime(6427));
        }

        [TestMethod]
        public void TrialDivisionMethod_ChecksBigRandomPrimeNumber_ReturnsTrue()
        {
            Assert.IsTrue(TrialDivision.IsPrime(1298747));
        }

        [TestMethod]
        public void TrialDivisionMethod_ChecksBigNonPrimeNumber_ReturnsFalse()
        {
            Assert.IsFalse(TrialDivision.IsPrime(1298749));
        }
    }
}
