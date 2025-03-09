using Creditas.CreditSimulator.Domain.Entities;

namespace Creditas.CreditSimulator.Domain.Contracts.Services
{
    public interface ICalculatorCreditService
    {
        CreditSimulationResult CalculateCredit(User user);
    }
}
