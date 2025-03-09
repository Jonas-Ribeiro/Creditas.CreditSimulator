using Creditas.CreditSimulator.Domain.Contracts.Services;
using Creditas.CreditSimulator.Domain.Entities;
using Creditas.CreditSimulator.Domain.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace Creditas.CreditSimulator.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    public class SimulationCreditController : Controller
    {

        private readonly ISimulatorService _simulatorService;

        public SimulationCreditController(ISimulatorService simulatorService)
        {
            _simulatorService = simulatorService;
        }

        ////<summary>
        ////Create a new simulation
        ////</summary>
        ////<param name="simulationRequest">object that contains parameters to simulate a credit</param>
        ////<returns> Return a simulation result</returns>
        [HttpPost("SimulationCredit")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreditSimulationResult>> Create([FromBody] SimulationRequest simulationRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var simulationResponse = await _simulatorService.SimulateCredit(simulationRequest);

            if (!simulationResponse.Success)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "A Error occurs during simulation, contact support.");
            }

            return Ok(simulationResponse);
        }
    }

}