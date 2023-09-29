/*using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using TransportModel.Queries;

namespace TransportWebApplication2.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class FilterProductEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public FilterProductEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterProducts([FromQuery] FilterProductQuery query)
        {
            try
            {
                var products = await _mediator.Send(query);
                return Ok(products);
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