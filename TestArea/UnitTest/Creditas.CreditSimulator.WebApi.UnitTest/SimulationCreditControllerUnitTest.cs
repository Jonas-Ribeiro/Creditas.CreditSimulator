using Creditas.CreditSimulator.Application.Services;
using Creditas.CreditSimulator.Controllers;
using Creditas.CreditSimulator.Domain.Contracts.Services;
using Creditas.CreditSimulator.Domain.Requests;
using Creditas.CreditSimulator.Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace Creditas.CreditSimulator.WebApi.UnitTest
{
    public class SimulationCreditControllerUnitTest
    {
        private readonly Mock<ISimulatorService> _mockSimulatorService;
        private readonly SimulationCreditController _controller;

        public SimulationCreditControllerUnitTest()
        {
            _mockSimulatorService = new Mock<ISimulatorService>();
            _controller = new SimulationCreditController(_mockSimulatorService.Object);
        }

        [Fact]
        public async Task Create_ShouldReturnOkResult_WhenRequestIsValid()
        {
            // Arrange
            var request = new SimulationRequest
            {
                Name = "John Doe",
                CreditRequest = 10000,
                BirthDate = new System.DateTime(1990, 1, 1),
                MonthsPaymentTerm = 12
            };

            var response = new SimulationResponse
            {
                TotalAmount = 11000,
                MonthlyPayment = 916.67,
                TotalFee = 1000,
                Success = true,
                Id = System.Guid.NewGuid()
            };

            _mockSimulatorService.Setup(s => s.SimulateCredit(request)).ReturnsAsync(response);

            // Act
            var result = await _controller.Create(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<SimulationResponse>(okResult.Value);
            Assert.Equal(response.TotalAmount, returnValue.TotalAmount);
            Assert.Equal(response.MonthlyPayment, returnValue.MonthlyPayment);
            Assert.Equal(response.TotalFee, returnValue.TotalFee);
            Assert.Equal(response.Success, returnValue.Success);
            Assert.Equal(response.Id, returnValue.Id);
        }

        [Fact]
        public async Task Create_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("Name", "Required");

            var request = new SimulationRequest
            {
                Name = "",
                CreditRequest = 10000,
                BirthDate = new System.DateTime(1990, 1, 1),
                MonthsPaymentTerm = 12
            };

            // Act
            var result = await _controller.Create(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task Create_ShouldReturnInternalServerError_WhenSimulationFails()
        {
            // Arrange
            var request = new SimulationRequest
            {
                Name = "John Doe",
                CreditRequest = 10000,
                BirthDate = new System.DateTime(1990, 1, 1),
                MonthsPaymentTerm = 12
            };

            var response = new SimulationResponse
            {
                TotalAmount = 11000,
                MonthlyPayment = 916.67,
                TotalFee = 1000,
                Success = false,
                Id = System.Guid.NewGuid()
            };

            _mockSimulatorService.Setup(s => s.SimulateCredit(request)).ReturnsAsync(response);

            // Act
            var result = await _controller.Create(request);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCodeResult.StatusCode);
            Assert.Equal("A Error occurs during simulation, contact support.", statusCodeResult.Value);
        }
    }
}