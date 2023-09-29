using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportModel.Commands;
using TransportModel.DTO;
using TransportModel.Model;
using TransportModel.Queries;

namespace TransportWebApplication.Controllers
{
    [ApiController]
    [Route("api/transporterscheduled")]
    public class ChangeStatusEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChangeStatusEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// This API will change status from Pending to Scheduled.if Transporter allocated to all the Product.
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <param>
        ///
        /// </param>
        /// <returns>  </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllTransporterScheduled()
        {
            try
            {
                var query = new ChangeStatusCommand();
                var transporterScheduled = await _mediator.Send(query);
                var response = new ApiResponse<ChangeStatusDTO>
                {
                    StatusCode = 200,
                    Status = "Success",
                    Success = true,
                    Error = null,
                    Message = "Status Update successfully",
                    Data = null,
                };
                return Ok(response);
                
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<InstructionDTO>
                {
                    StatusCode = 400,
                    Status = "Error",
                    Success = false,
                    Error = ex.Message,
                    Message = "An error  while updating the  Status."
                };
                return BadRequest(response);
            }
        }
    }
}




