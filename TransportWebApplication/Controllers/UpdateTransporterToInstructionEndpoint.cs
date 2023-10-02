
using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.DTO;

[Route("api/instructionproducts")]
[ApiController]
public class UpdateTransporterToInstructionEndpoint : ControllerBase
{
    private readonly IMediator _mediator;

    public UpdateTransporterToInstructionEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

  

    /// <summary>
    /// This API allocate Transporter to  the Products.
    /// </summary>
    /// <remarks>
    /// Allocate the Transporter Id and the Scheduled Date for the product.
    /// </remarks>
    /// <param name="updateDTO">
    /// Take the Transporter Id and the Scheduled Date.
    /// </param>
    /// <returns> 200 success for successfully added the Transporter. </returns>
    [HttpPost("addTransporter")]
    public async Task<IActionResult> AddTransporterToInstructionProduct(InstructionProductUpdateListDTO request)
    {
       
        var productList = new UpdateTransporterToInstructionCommand { InstructionId = request.InstructionId, TransporterProducts = request.TransporterProducts };
        var results = await _mediator.Send(productList);

        if (results != null)
        {

            var changeStatusCommand = new ChangeStatusCommand { instructionid=request.InstructionId};
            if (changeStatusCommand.instructionid != 0)
            {
                await _mediator.Send(changeStatusCommand);
                var responsesucess = new ApiResponse<IEnumerable<ChangeStatusDTO>>
                {
                    StatusCode = 200,
                    Status = "Success",
                    Success = true,
                    Error = null,
                    Message = "Transporter Scheduled  successfully",
                    Data = null,
                };
                return Ok(responsesucess);
            }
            var response = new ApiResponse<IEnumerable<ChangeStatusDTO>>
            {
                StatusCode = 400,
                Status = "Error",
                Success = false,
                Error = "The instruction Id is not provided.",
                Message = "An error occurred while updating the status of  your request"
            };
            return BadRequest(response);
        }
        else
        {
            var response = new ApiResponse<IEnumerable<ChangeStatusDTO>>
            {
                StatusCode = 400,
                Status = "Error",
                Success = false,
                Error = "No results found for particular request.",
                Message = "An error occurred while processing your request"
            };
            return BadRequest(response);
        }

        
       


    }

}

