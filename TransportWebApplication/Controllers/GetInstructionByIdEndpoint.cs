using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using TransportModel.Queries;
using TransportModel.DTO;
using TransportModel.Model;

namespace TransportWebApplication.Controllers
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
                    var responseerror = new ApiResponse<ChangeStatusDTO>
                    {
                        StatusCode = 400,
                        Status = "Error",
                        Success = false,
                        Error = "Instruction Not Found",
                        Message = "An error occurred while processing your request"
                    };
                    return BadRequest(responseerror);
                }
                var response = new ApiResponse<InstructionNameDTO>
                {
                    StatusCode = 200,
                    Status = "Success",
                    Success = true,
                    Error = null,
                    Message = "Instructions retrieved successfully",
                    Data = instruction,
                };
                return Ok(response);
               
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response
                var response = new ApiResponse<ChangeStatusDTO>
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
