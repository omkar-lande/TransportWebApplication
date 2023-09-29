using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using TransportModel.Queries;

namespace TransportWebApplication2.Controllers
{
    [ApiController]
    [Route("api/instructions")]
    public class GetAllInstructionEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetAllInstructionEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// This API will fetch all the Instruction from database.
        /// </summary>
        /// <remarks>
        /// retrieve all the instruction from the Database.
        /// </remarks>
        /// <returns>  List of all Instruction with CreatedDate, ClientName, PickupAdress, DeliveryAdress and Status. </returns>

        [HttpGet]
        public async Task<IActionResult> GetAllInstructions()
        {
            try
            {
                var query = new GetAllInstructionsQuery();
                var instructions = await _mediator.Send(query);
                return Ok(instructions);
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response
                return BadRequest(ex.Message);
            }
        }
    }
}
