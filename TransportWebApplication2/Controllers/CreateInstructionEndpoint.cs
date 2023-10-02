

using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportModel.Commands;
using TransportModel.DTO;
using TransportModel.Model;

[ApiController]
[Route("api/instructions")]
public class CreateInstructionEndpoint : ControllerBase
{
    private readonly IMediator _mediator;

    public CreateInstructionEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// This API Create the  Instruction.
    /// </summary>
    /// <remarks>
    /// Creating the instruction for Placing the order.
    /// </remarks>
    /// <param name="request"> 
    /// This API needs The ClientId, PickupAddress, DeliveryAddress, productId and ProductQuantity To Create an Instruction.
    /// </param>
    /// <returns>200 ok status</returns>
    [HttpPost]
    public async Task<IActionResult> CreateInstruction(CreateInstructionDTO request)
    {
        try
        {
            var createInstructionCommand = new CreateInstrucionCommand { Instruction = request };
            int  result = await _mediator.Send(createInstructionCommand);
            if (result!=0)
            {
                var response = new ApiResponse<int>
                {
                    StatusCode = 200,
                    Status = "Success",
                    Success = true,
                    Error = null,
                    Message = "Instruction Created successfully",
                    Data = result,
                };
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<int>
                {
                    StatusCode = 400,
                    Status = "Error",
                    Success = false,
                    Error = "Instruction is not created.",
                    Message = "An error occurred while Creating the request"
                };
                return BadRequest(response);
            }
        }
        catch (Exception ex)
        {
            var response = new ApiResponse<IEnumerable<int>>
            {
                StatusCode = 400,
                Status = "Error",
                Success = false,
                Error = ex.Message,
                Message = "An error occurred while Creating the request"
            };
            return BadRequest(response);
        }
    }
}
