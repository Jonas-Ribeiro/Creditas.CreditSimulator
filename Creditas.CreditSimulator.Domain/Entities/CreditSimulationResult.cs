using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creditas.CreditSimulator.Domain.Entities
{
    public class CreditSimulationResult
    {
        public readonly double TotalAmount;
        public readonly double MonthlyPayment;
        public readonly double TotalFee;
        public readonly Guid Id;

        public CreditSimulationResult(double totalAmount, double monthlyPayment, double totalFee, Guid id = default)
        {
            TotalAmount = totalAmount;
            MonthlyPayment = monthlyPayment;
            TotalFee = totalFee;
            Id = id == default ? Guid.NewGuid() : id;
        }
    }
}
