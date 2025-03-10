using AutoFixture;
using Creditas.CreditSimulator.Domain.Contracts.Services;
using Creditas.CreditSimulator.Domain.Entities;
using Creditas.CreditSimulator.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace Creditas.CreditSimulator.Infrastructure.UnitTest
{
    public class CalculatorCreditServiceUnitTest
    {
        private readonly Mock<IFeeService> _mockFeeService;
        private readonly Mock<ILogger<CalculatorCreditService>> _mockLogger;
        private readonly CalculatorCreditService _calculatorCreditService;
        private readonly Fixture _fixture;

        public CalculatorCreditServiceUnitTest()
        {
            _mockFeeService = new Mock<IFeeService>();
            _mockLogger = new Mock<ILogger<CalculatorCreditService>>();
            _calculatorCreditService = new CalculatorCreditService(_mockFeeService.Object, _mockLogger.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public void CalculateCredit_ShouldReturnCorrectSimulationResult()
        {
            // Arrange
            var user = new User("John Doe", 10000, new DateTime(1990, 1, 1), 12);
            _mockFeeService.Setup(f => f.GetMonthFee(user.BirthDate)).Returns(0.01); // 1% monthly fee

            // Act
            var result = _calculatorCreditService.CalculateCredit(user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(10000 * 0.01 / (1 - Math.Pow(1 + 0.01, -12)), result.MonthlyPayment, precision: 2);
            Assert.Equal(result.MonthlyPayment * 12, result.TotalAmount, precision: 2);
            Assert.Equal(0.01 * 12, result.TotalFee, precision: 2);
            Assert.NotEqual(Guid.Empty, result.Id);
        }

        [Fact]
        public void CalculateCredit_ShouldThrowException_WhenUserIsNull()
        {                       
            // Act & Assert
            Assert.Throws<NullReferenceException>(() => _calculatorCreditService.CalculateCredit(null));
        }
    }
}
