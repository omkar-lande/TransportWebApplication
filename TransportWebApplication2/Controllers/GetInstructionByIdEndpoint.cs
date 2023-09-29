using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using TransportModel.Queries;

namespace TransportWebApplication2.Controllers
{
    [ApiController]
    [Route("api/instructions")]
    public class GetInstructionByIdEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetInstructionByIdEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// This API will fetch all the Instruction base on Id from database.
        /// </summary>
        /// <remarks>
        /// Retrieve the Instruction and their productList.
        /// </remarks>
        /// <param>
        /// Take the InstructionId as a Parameter.
        /// </param>
        /// <returns> Returns the Instruction Which match with Id and the ProductList by ProductName, ProductQuantity and InstructionProductId. </returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstructionById(int id)
        {
            try
            {
                var query = new GetInstructionQuery { Id = id };
                var instruction = await _mediator.Send(query);

                if (instruction == null)
                {
                    return NotFound(); // Instruction not found
                }

                return Ok(instruction);
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response
                return BadRequest(ex.Message);
            }
        }
    }
}
