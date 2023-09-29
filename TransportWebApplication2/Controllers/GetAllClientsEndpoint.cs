using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportModel.Queries;

namespace TransportWebApplication.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class GetAllClientsEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;


        public GetAllClientsEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// This API will fetch all the clients from database.
        /// </summary>
        /// <remarks>
        /// Client list is an array of Clients with its name and id.
        /// </remarks>
        /// <param>
        ///
        /// </param>
        /// <returns> List of clients with name and its id </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            try
            {
                var query = new GetAllClientsQuery();
                var clients = await _mediator.Send(query);
                return Ok(clients);
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response
                return BadRequest(ex.Message);
            }
        }
    }
}

