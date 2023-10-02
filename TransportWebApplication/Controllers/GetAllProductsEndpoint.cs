using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportModel.DTO;
using TransportModel.Model;
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
            var response = new ApiResponse<IEnumerable<ProductDTO>>
            {
                StatusCode = 200,
                Status = "Success",
                Success = true,
                Error = null,
                Message = "Instructions retrieved successfully",
                Data = products,
            };
            return Ok(response);
           
        }
        catch (Exception ex)
        {
            var response = new ApiResponse<IEnumerable<ProductDTO>>
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
