using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportModel.Model;
using TransportModel.Queries;

namespace TransportWebApplication.Controllers
{
    [ApiController]
    [Route("api/TransporterList")]
    public class GetAllTransporterEndpoint: ControllerBase
    {
        private readonly IMediator _mediator;

        public GetAllTransporterEndpoint(IMediator mediator)
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
                return Ok(transporters);
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response
                return BadRequest(ex.Message);
            }
        }
    }
}
