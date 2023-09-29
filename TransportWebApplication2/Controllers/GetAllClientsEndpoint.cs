using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportModel.DTO;
using TransportModel.Model;
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

                var response = new ApiResponse<IEnumerable<ClientDTO>> 
                {
                    StatusCode = 200,
                    Status = "Success",
                    Success = true,
                    Error = null,
                    Message = "Clients retrieved successfully",
                    Data = clients
                };

                return Ok(response);
                //return Ok(clients);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<ClientDTO>> 
                {
                    StatusCode = 400, // Bad Request status code
                    Status = "Error",
                    Success = false,
                    Error = ex.Message,
                    Message = "An error occurred while processing your request"
                };
                return BadRequest(response);
            }
        }

       
    }
}

