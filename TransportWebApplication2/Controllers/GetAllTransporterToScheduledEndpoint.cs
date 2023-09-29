using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportModel.DTO;
using TransportModel.Model;
using TransportModel.Queries;

namespace TransportWebApplication.Controllers
{
    [ApiController]
    [Route("api/GetTransporterScheduled")]
    public class GetAllTransporterToScheduledEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;
        public GetAllTransporterToScheduledEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// This API will fetch all the pending  Instruction in the database.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param>
        /// 
        /// </param>
        /// <returns>  Retrieve the Instruction and the List of products associated to it which are pending to Scheduled.  </returns>


        [HttpGet]
        public async Task<IActionResult> GetAllTransporterScheduled()
        {
            try
            {
                var query = new GetAllTransporterToScheduledQuery();
                var TransporterScheduled = await _mediator.Send(query);
                var response = new ApiResponse<IEnumerable<GetTransporterScheduledDTO>>
                {
                    StatusCode = 200,
                    Status = "Success",
                    Success = true,
                    Error = null,
                    Message = "Instructions retrieved successfully",
                    Data = TransporterScheduled,
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<GetTransporterScheduledDTO>>
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
