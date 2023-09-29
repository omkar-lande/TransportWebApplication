using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportModel.Queries;

[ApiController]
[Route("api/products")]
public class GetAllProductsEndpoint : ControllerBase
{
    private readonly IMediator _mediator;

    public GetAllProductsEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }
    /// <summary>
    /// This API will fetch all the Products from database.
    /// </summary>
    /// <remarks>
    /// Product list is an array of products with its name and id.
    /// </remarks>
    /// <param>
    /// 
    /// </param>
    /// <returns> List of Product with id, name and its Description. </returns>
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        try
        {
            var query = new GetAllProductsQuery();
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
