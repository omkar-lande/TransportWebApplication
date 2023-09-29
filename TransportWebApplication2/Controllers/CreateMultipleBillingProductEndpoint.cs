/*using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.Model;

namespace TransportWebApplication.Controllers
{
    [ApiController]
    [Route("api/billingproducts")]
    public class CreateMultipleBillingProductEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateMultipleBillingProductEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBillingProducts([FromBody] List<BillingProductDto> billingProducts)
        {
            try
            {
                var createBillingProductsCommand = new CreateMultipleBillingProductsCommand
                {
                    BillingProducts = billingProducts,
                };

                var billingProductIds = await _mediator.Send(createBillingProductsCommand);

                return Ok(billingProductIds);
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