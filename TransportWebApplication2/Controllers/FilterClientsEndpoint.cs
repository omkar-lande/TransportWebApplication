/*using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using TransportModel.Queries;

namespace TransportWebApplication2.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class FilterClientsEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public FilterClientsEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterClients([FromQuery] FilterClientsQuery query)
        {
            try
            {
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
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using TransportModel.Queries;

namespace TransportWebApplication2.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class FilterClientsEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public FilterClientsEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterClients( FilterClientsQuery query)
        {
            try
            {
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
*/