using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeNumbers;
using System.Collections.Generic;
using System.Linq;

namespace PrimeFactosTests
{
    [TestClass]
    public class PrimeFactorsTests
    {
        [TestMethod]
        public void PrimeFactors_ReceivesTwo_ReturnsTwo()
        {
            var primeFactors = PrimeFactors.Generate(2);
            Assert.AreEqual(primeFactors.First(), 2);
        }

        [TestMethod]
        public void PrimeFactors_ReceivesThree_ReturnsOneAndThree()
        {
            var primeFactors = PrimeFactors.Generate(3);
            Assert.AreEqual(primeFactors.First(), 3);
        }

        [TestMethod]
        public void PrimeFactors_ReceivesFour_ReturnsTwoTwo()
        {
            var primeFactors = PrimeFactors.Generate(4);
            CollectionAssert.AreEqual(primeFactors, new List<int>{2,2});
        }

        [TestMethod]
        public void PrimeFactors_ReceivesFive_ReturnsFive()
        {
            var primeFactors = PrimeFactors.Generate(5);
            Assert.AreEqual(primeFactors.First(), 5);
        }

        [TestMethod]
        public void PrimeFactors_ReceivesSix_ReturnsTwoThree()
        {
            var primeFactors = PrimeFactors.Generate(6);
            CollectionAssert.AreEqual(primeFactors, new List<int>{2,3});
        }

        [TestMethod]
        public void PrimeFactors_ReceivesSeven_ReturnsSeven()
        {
            var primeFactors = PrimeFactors.Generate(7);
            Assert.AreEqual(primeFactors.First(), 7);
        }

        [TestMethod]
        public void PrimeFactors_ReceivesEight_ReturnsTwoTwoTwo()
        {
            var primeFactors = PrimeFactors.Generate(8);
            CollectionAssert.AreEqual(primeFactors, new List<int> { 2, 2 ,2});
        }

        [TestMethod]
        public void PrimeFactors_ReceivesNine_ReturnsThreeThree()
        {
            var primeFactors = PrimeFactors.Generate(9);
            CollectionAssert.AreEqual(primeFactors, new List<int> { 3, 3});
        }

        [TestMethod]
        public void PrimeFactors_ReceivesTen_ReturnsTwoFive()
        {
            var primeFactors = PrimeFactors.Generate(10);
            CollectionAssert.AreEqual(primeFactors, new List<int> {2, 5});
        }

        [TestMethod]
        public void PrimeFactors_ReceivesBigNumber_PrimeFactorizationIsCorrect()
        {
            var primeFactors = PrimeFactors.Generate(4569878);
            CollectionAssert.AreEqual(primeFactors, new List<int>{2, 29, 78791});
        }

        [TestMethod]
        public void PrimeFactors_ReceivesAnotherBigNumber_PrimeFactorizationIsCorrect()
        {
            var primeFactors = PrimeFactors.Generate(793800);
            CollectionAssert.AreEqual(primeFactors, new List<int> {2,2,2,3,3,3,3,5,5,7,7});
        }

        [TestMethod]
        public void PrimeFactors_ReceivesPrimeNumber_ReturnsPrimeNumber()
        {
            var primeFactors = PrimeFactors.Generate(919);
            Assert.AreEqual(primeFactors.First(), 919);
        }

        [TestMethod]
        public void PrimeFactors_ReceivesOne_ReturnsEmptyList()
        {
            var primeFactors = PrimeFactors.Generate(1);
            Assert.AreEqual(primeFactors.Count, 0);
        }

    }
}
