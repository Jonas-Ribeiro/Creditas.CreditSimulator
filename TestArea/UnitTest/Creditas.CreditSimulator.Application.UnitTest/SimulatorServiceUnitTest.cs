using AutoMapper;
using Creditas.CreditSimulator.Application.Services;
using Creditas.CreditSimulator.Domain.Contracts.Services;
using Creditas.CreditSimulator.Domain.Entities;
using Creditas.CreditSimulator.Domain.Requests;
using Creditas.CreditSimulator.Domain.Responses;
using Microsoft.Extensions.Logging;
using Moq;

namespace Creditas.CreditSimulator.Application.UnitTest
{

    public class SimulatorServiceUnitTest
    {
        private readonly Mock<ICalculatorCreditService> _mockCalculatorCreditService;
        private readonly Mock<ILogger<SimulatorService>> _mockLogger;
        private readonly Mock<IMapper> _mockMapper;
        private readonly SimulatorService _simulatorService;

        public SimulatorServiceUnitTest()
        {
            _mockCalculatorCreditService = new Mock<ICalculatorCreditService>();
            _mockLogger = new Mock<ILogger<SimulatorService>>();
            _mockMapper = new Mock<IMapper>();
            _simulatorService = new SimulatorService(_mockCalculatorCreditService.Object, _mockLogger.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task SimulateCredit_ShouldReturnSimulationResponse_WhenRequestIsValid()
        {
            // Arrange
            var simulationRequest = new SimulationRequest
            {
                Name = "John Doe",
                CreditRequest = 10000,
                BirthDate = new DateTime(1990, 1, 1),
                MonthsPaymentTerm = 12
            };

            var user = new User(simulationRequest.Name, simulationRequest.CreditRequest, simulationRequest.BirthDate.Value, simulationRequest.MonthsPaymentTerm);
            var creditSimulationResult = new CreditSimulationResult(12000, 1000, 5, Guid.NewGuid());
            var simulationResponse = new SimulationResponse
            {
                TotalAmount = creditSimulationResult.TotalAmount,
                MonthlyPayment = creditSimulationResult.MonthlyPayment,
                TotalFee = creditSimulationResult.TotalFee,
                Id = creditSimulationResult.Id,
                Success = true
            };

            _mockMapper.Setup(m => m.Map<User>(It.IsAny<SimulationRequest>())).Returns(user);
            _mockMapper.Setup(m => m.Map<SimulationResponse>(It.IsAny<CreditSimulationResult>())).Returns(simulationResponse);
            _mockCalculatorCreditService.Setup(s => s.CalculateCredit(It.IsAny<User>())).Returns(creditSimulationResult);

            // Act
            var result = await _simulatorService.SimulateCredit(simulationRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(creditSimulationResult.TotalAmount, result.TotalAmount);
            Assert.Equal(creditSimulationResult.MonthlyPayment, result.MonthlyPayment);
            Assert.Equal(creditSimulationResult.TotalFee, result.TotalFee);
            Assert.Equal(creditSimulationResult.Id, result.Id);
            Assert.True(result.Success);
        }
    }
}