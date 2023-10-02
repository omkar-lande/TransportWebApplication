using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportModel.DTO;
using TransportModel.Model;
using TransportModel.Queries;

namespace TransportWebApplication.Controllers
{
    [ApiController]
    [Route("api/TransporterList")]
    public class GetAllTransportersEndpoint: ControllerBase
    {
        private readonly IMediator _mediator;

        public GetAllTransportersEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// This API will fetch all the Transporter from database.
        /// </summary>
        /// <remarks>
        /// Transporter list is an array of Clients with its name and id.
        /// </remarks>
        /// <param>
        ///
        /// </param>
        /// <returns> List of Transporter with name and its id </returns>

        [HttpGet]
        public async Task<IActionResult> GetAllTransporter()
        {
            try
            {
                var query = new GetAllTransporterQuery();
                var transporters = await _mediator.Send(query);
                var response = new ApiResponse<IEnumerable<TransporterDTO>>
                {
                    StatusCode = 200,
                    Status = "Success",
                    Success = true,
                    Error = null,
                    Message = "Instructions retrieved successfully",
                    Data = transporters,
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response
                return BadRequest(ex.Message);
            }
        }
    }
}
