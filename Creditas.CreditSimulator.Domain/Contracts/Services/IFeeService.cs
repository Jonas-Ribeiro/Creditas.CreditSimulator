using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creditas.CreditSimulator.Domain.Contracts.Services
{
    public interface IFeeService
    {
        double GetMonthFee(DateTime birthDate);
    }
}
