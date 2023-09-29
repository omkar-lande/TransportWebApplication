using MediatR;
using Microsoft.AspNetCore.Mvc;
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
                return Ok(TransporterScheduled);
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response
                return BadRequest(ex.Message);
            }
        }
    }
}
