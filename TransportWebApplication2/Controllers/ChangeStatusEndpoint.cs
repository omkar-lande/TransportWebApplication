using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportModel.Commands;
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
                return Ok(transporterScheduled);
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response
                return BadRequest(ex.Message);
            }
        }
    }
}




