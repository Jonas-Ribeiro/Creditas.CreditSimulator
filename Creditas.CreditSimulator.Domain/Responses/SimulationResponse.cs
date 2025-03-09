using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creditas.CreditSimulator.Domain.Responses
{
    public class SimulationResponse
    {
        public double TotalAmount { get; set; }
        public double MonthlyPayment { get; set; }
        public double TotalFee { get; set; }
        public bool Success { get; set; }
    }
}
