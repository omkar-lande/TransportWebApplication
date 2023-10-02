using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using TransportModel.Queries;
using TransportModel.DTO;
using TransportModel.Model;

namespace TransportWebApplication2.Controllers
{
    [ApiController]
    [Route("api/instructions")]
    public class GetAllInstructionsEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetAllInstructionsEndpoint(IMediator mediator)
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
                var response = new ApiResponse<IEnumerable<InstructionDTO>> 
                {
                    StatusCode = 200,
                    Status = "Success",
                    Success = true,
                    Error = null,
                    Message = "Instructions retrieved successfully",
                    Data = instructions,
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<InstructionDTO>>
                {
                    StatusCode = 400, 
                    Status = "Error",
                    Success = false,
                    Error = ex.Message,
                    Message = "An error occurred while processing your request"
                };
                return BadRequest(response);
            }
        }
    }
}
