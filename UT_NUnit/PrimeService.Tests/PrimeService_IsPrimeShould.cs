using NUnit.Framework;
using Prime.Services;

namespace Tests
{
    [TestFixture]
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        [Test]
        public void ReturnFalseGivenValueOf1()
        {
            var result = _primeService.IsPrime(1);
            Assert.IsFalse(result, "1 not a prime");
        }

        [Test]
        public void ReturnFalseGivenValueOf87()
        {
            var result = _primeService.IsPrime(87);
            Assert.IsFalse(result, "87 is not a prime");
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void ReturnFalseGivenValuesLessThan2(int value)
        {
            var result = _primeService.IsPrime(value);
            Assert.IsFalse(result, $"{value} should not be prime");
        }

        [TestCase(11)]
        [TestCase(13)]
        [TestCase(17)]
        [TestCase(19)]
        [TestCase(23)]
        [TestCase(29)]
        [TestCase(31)]
        [TestCase(37)]
        [TestCase(83)]
        [TestCase(997)]
        [TestCase(991)]
        [TestCase(983)]
        [TestCase(977)]
        [TestCase(971)]
        [TestCase(967)]
        public void ReturnTrueGivenValuesIsPrime(int value)
        {
            var result = _primeService.IsPrime(value);
            Assert.IsTrue(result, $"{value} should BE prime");
        }
    }
}