using System;
using Creditas.CreditSimulator.Infrastructure.Services;
using Xunit;

namespace Creditas.CreditSimulator.Infrastructure.UnitTest
{
    public class FeeServiceUnitTest
    {
        private readonly FeeService _feeService;

        public FeeServiceUnitTest()
        {
            _feeService = new FeeService();
        }

        [Theory]
        [InlineData("2000-01-01", 5.0 / 100 / 12)] // Age <= 25
        [InlineData("1990-01-01", 3.0 / 100 / 12)] // 26 <= Age < 40
        [InlineData("1975-01-01", 2.0 / 100 / 12)] // 41 <= Age < 60
        [InlineData("1950-01-01", 4.0 / 100 / 12)] // Age > 60
        public void GetMonthFee_ShouldReturnCorrectFeeBasedOnAge(string birthDateString, double expectedFee)
        {
            // Arrange
            var birthDate = DateTime.Parse(birthDateString);

            // Act
            var result = _feeService.GetMonthFee(birthDate);

            // Assert
            Assert.Equal(expectedFee, result, precision: 5);
        }
    }
}