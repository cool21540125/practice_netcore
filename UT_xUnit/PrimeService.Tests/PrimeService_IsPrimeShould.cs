using Xunit;
using Prime.Services;

namespace Tests
{
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        [Fact]
        public void ReturnFalseGivenValueOf1()
        {
            var result = _primeService.IsPrime(1);
            Assert.False(result, "1 not a prime");
        }

        [Fact]
        public void ReturnFalseGivenValueOf87()
        {
            var result = _primeService.IsPrime(87);
            Assert.False(result, "87 is not a prime");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void ReturnFalseGivenValuesLessThan2(int value)
        {
            var result = _primeService.IsPrime(value);
            Assert.False(result, $"{value} should not be prime");
        }

        [InlineData(11)]
        [InlineData(13)]
        [InlineData(17)]
        [InlineData(19)]
        [InlineData(23)]
        [InlineData(29)]
        [InlineData(31)]
        [InlineData(37)]
        [InlineData(83)]
        [InlineData(997)]
        [InlineData(991)]
        [InlineData(983)]
        [InlineData(977)]
        [InlineData(971)]
        [InlineData(967)]
        public void ReturnTrueGivenValuesIsPrime(int value)
        {
            var result = _primeService.IsPrime(value);
            Assert.True(result, $"{value} should BE prime");
        }
    }
}