using Creditas.CreditSimulator.Domain.Contracts.Services;
using Creditas.CreditSimulator.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Creditas.CreditSimulator.Infrastructure.Services
{
    public class CalculatorCreditService : ICalculatorCreditService
    {
        private readonly IFeeService _feeService;
        private readonly ILogger<CalculatorCreditService> _logger;

        public CalculatorCreditService(IFeeService feeService, ILogger<CalculatorCreditService> logger)
        {
            _feeService = feeService;
            _logger = logger;
        }
        public CreditSimulationResult CalculateCredit(User user)
        {
            double monthFee = _feeService.GetMonthFee(user.BirthDate);
            
            double numerator = user.CreditRequest * monthFee;            
            double denominator = 1 - (Math.Pow(1 + monthFee, - user.MonthsPaymentTerm));
            double monthlyPayment = numerator / denominator;            
            double totalAmount = monthlyPayment * user.MonthsPaymentTerm;
            double totalFee = monthFee * user.MonthsPaymentTerm;

            var creditSimulationResult = new CreditSimulationResult(totalAmount, monthlyPayment, totalFee);

            return creditSimulationResult;            
        }
    }
}
