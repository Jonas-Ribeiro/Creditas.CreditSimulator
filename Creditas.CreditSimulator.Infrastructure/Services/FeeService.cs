using Creditas.CreditSimulator.Domain.Contracts.Services;
using Creditas.CreditSimulator.Infrastructure.Services.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creditas.CreditSimulator.Infrastructure.Services
{
    public class FeeService : IFeeService
    {
        public double GetMonthFee(DateTime birthDate)
        {
            var userAge = DateTime.Now.Year - birthDate.Year;

            double fee = 0;

            switch (userAge)
            {
                case var age when age <= 25:
                    fee = 5.0;
                    break;
                case var age when age >= 26 && age < 40:
                    fee = 3.0;
                    break;
                case var age when age >= 41 && age < 60:
                    fee = 2.0;
                    break;
                case var age when age > 60:
                    fee = 4.0;
                    break;
            }

            return CalculateFee(fee);
        }

        private static double CalculateFee(double fee) => (fee / 100) / ServiceConstants.MONTHS_IN_YEAR;        
    }
}
