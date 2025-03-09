using Creditas.CreditSimulator.Domain.Entities;
using Creditas.CreditSimulator.Domain.Requests;
using Creditas.CreditSimulator.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Creditas.CreditSimulator.Domain.Contracts.Services
{
    public interface ISimulatorService
    {
        Task<SimulationResponse> SimulateCredit(SimulationRequest user);
    }
}
