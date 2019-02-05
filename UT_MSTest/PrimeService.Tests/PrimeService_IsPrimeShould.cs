using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prime.Services;

namespace Tests
{
    [TestClass]
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        [TestMethod]
        public void ReturnFalseGivenValueOf1()
        {
            var result = _primeService.IsPrime(1);
            Assert.IsFalse(result, "1 not a prime");
        }

        [TestMethod]
        public void ReturnFalseGivenValueOf87()
        {
            var result = _primeService.IsPrime(87);
            Assert.IsFalse(result, "87 is not a prime");
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1)]
        public void ReturnFalseGivenValuesLessThan2(int value)
        {
            var result = _primeService.IsPrime(value);
            Assert.IsFalse(result, $"{value} should not be prime");
        }

        [DataTestMethod]
        [DataRow(11)]
        [DataRow(13)]
        [DataRow(17)]
        [DataRow(19)]
        [DataRow(23)]
        [DataRow(29)]
        [DataRow(31)]
        [DataRow(37)]
        [DataRow(83)]
        [DataRow(997)]
        [DataRow(991)]
        [DataRow(983)]
        [DataRow(977)]
        [DataRow(971)]
        [DataRow(967)]
        public void ReturnTrueGivenValuesIsPrime(int value)
        {
            var result = _primeService.IsPrime(value);
            Assert.IsTrue(result, $"{value} should BE prime");
        }
    }
}