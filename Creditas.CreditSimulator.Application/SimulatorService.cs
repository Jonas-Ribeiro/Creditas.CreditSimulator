using AutoMapper;
using Creditas.CreditSimulator.Domain.Contracts.Services;
using Creditas.CreditSimulator.Domain.Entities;
using Creditas.CreditSimulator.Domain.Requests;
using Creditas.CreditSimulator.Domain.Responses;
using Microsoft.Extensions.Logging;

namespace Creditas.CreditSimulator.Application
{
    public class SimulatorService : ISimulatorService
    {
        private readonly ICalculatorCreditService _calculatorCreditService;
        private readonly ILogger<SimulatorService> _logger;
        private readonly IMapper _mapper;
        public SimulatorService(ICalculatorCreditService calculatorCreditService, ILogger<SimulatorService> logger, IMapper mapper)
        {
            _calculatorCreditService = calculatorCreditService;
            _logger = logger;
            _mapper = mapper;
        }

        public Task<SimulationResponse> SimulateCredit(SimulationRequest simulationRequest)
        {
            try
            {
                var user = _mapper.Map<User>(simulationRequest);

                var creditSimulationResult = _calculatorCreditService.CalculateCredit(user);

                SimulationResponse simulationResponse = _mapper.Map<SimulationResponse>(creditSimulationResult);
                simulationResponse.Success = true;

                return Task.FromResult(simulationResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error during credit simulation: {ex.message}", ex.Message);

                return Task.FromResult(new SimulationResponse { Success = false});
            }
        }
    }
}
