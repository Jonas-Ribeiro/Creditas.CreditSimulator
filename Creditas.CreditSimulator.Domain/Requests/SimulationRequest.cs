using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creditas.CreditSimulator.Domain.Requests
{
    public class SimulationRequest
    {
        [Required(ErrorMessage = "Name could not be empty")]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Credit Request should be higher than zero")]
        public double CreditRequest { get; set; }

        [Required(ErrorMessage = "BirthDate could not be empty")]
        public DateTime? BirthDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Months Payment Term should be higher than zero")]
        public int MonthsPaymentTerm { get; set; }
    }
}
