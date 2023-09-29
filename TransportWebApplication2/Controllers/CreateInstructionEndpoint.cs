/*using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.Model;

namespace TransportWebApplication2.Controllers
{
    public class CreateInstructionEndpoint : EndpointBaseAsync<CreateInstructionRequest, CreateInstructionResponse>
    {
        private readonly IMediator _mediator;

        public CreateInstructionEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/api/instructions")]
        public override async Task<ActionResult<CreateInstructionResponse>> HandleAsync(CreateInstructionRequest request)
        {
            var command = new CreateInstrucionCommand { Request = request };
            var instructionId = await _mediator.Send(command);

            var response = new CreateInstructionResponse { InstructionId = instructionId };

            return Ok(response);
        }
    }
}
*/
/*
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TransportModel.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;
using TransportModel.Data;
using TransportModel.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TransportWebApplication2.Controllers
{
    [ApiController]
    [Route("api/instructions")]
    public class CreateInstructionEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;
        public CreateInstructionEndpoint(IMediator mediator, ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstruction([FromBody] CreateInstrucionCommand request)
        {
            try
            {
                var client = _context.ClientLists.FirstOrDefault(c => c.ClientName == request.Instruction.ClientName);

                if (client == null)
                {
                    // Handle the case where the client with the provided name doesn't exist
                    return BadRequest("Client not found for the provided name.");
                }

                // Set ClientId based on the found client
                request.Instruction.ClientId = client.ClientId;
                
                // Calculate BillingId as MaxInstructionId + 1
                //int maxInstructionId = _context.Instructions.Max(i => i.InstructionId);
                //request.Instruction.BillingId = maxInstructionId + 1;

                var instructionId = await _mediator.Send(request);

                return Ok(instructionId);
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

/*

using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.Data;
using TransportModel.DTO;
using TransportModel.Model;

namespace TransportWebApplication2.Controllers
{
    [ApiController]
    [Route("api/instructions")]
    public class CreateInstructionEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;
        private readonly IInstructionDataAcess _instructionDataAccess;

        public CreateInstructionEndpoint(
            IMediator mediator,
            ApplicationDbContext context,
            IInstructionDataAcess instructionDataAccess)
        {
            _mediator = mediator;
            _context = context;
            _instructionDataAccess = instructionDataAccess;
        }



        /// <summary>
        /// This API Create the  Instruction.
        /// </summary>
        /// <remarks>
        /// Creating the instruction for Placing the order.
        /// </remarks>
        /// <param name="request"> 
        /// This API needs The ClientId, PickupAddress, DeliveryAddress, productId and ProductQuantity To Create an Instruction.
        /// </param>
        /// <returns>200 ok status</returns>

       
        [HttpPost]
        public async Task<IActionResult> CreateInstruction(CreateInstructionDTO request)
{
            try
            {
               
                
                List<InstructionProduct> billingProducts = new List<InstructionProduct>();

                foreach (var product in request.ProductList)
                {
                    InstructionProduct billingProduct = new InstructionProduct();
                    billingProduct.ProductId = product.ProductId;
                    billingProduct.Quantity = product.Quantity;
                   billingProduct.InstructionId = product.InstructionId;
                   billingProduct.ScheduledDate = null;
                   billingProduct.TransporterId =null;
                  

                   // billingProduct.TransportScheduled = null;
                    billingProducts.Add(billingProduct);

                }

                Instruction instruction = new Instruction()
                {
                    CreatedDate = request.CreatedDate,
                    PickupAddress = request.PickupAddress,
                    DeliveryAddress = request.DeliveryAddress,
                    ClientsId = request.ClientsId,
                    instructionProducts = billingProducts,
                    Status = TransportModel.Model.Enum.Status.Pending,

                };


                
                _context.Instruction.Add(instruction);

                  await _context.SaveChangesAsync();

                // Return the newly created instruction's 
               // var Id = await _mediator.Send(new CreateInstrucionCommand { Instruction = newInstruction });
               // await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response
                return BadRequest(ex.Message);
            }
        }

        private async Task<int?> GetClientIdByClientName(string clientName)
        {
            // Implement the logic to retrieve the client ID based on the client name
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Name == clientName);
            return client?.Id;
        }
       
    }
}

*/

using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportModel.Commands;
using TransportModel.DTO;

[ApiController]
[Route("api/instructions")]
public class CreateInstructionEndpoint : ControllerBase
{
    private readonly IMediator _mediator;

    public CreateInstructionEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateInstruction(CreateInstructionDTO request)
    {
        try
        {
            var createInstructionCommand = new CreateInstrucionCommand { Instruction = request };
            int  result = await _mediator.Send(createInstructionCommand);
            if (result!=0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Failed to create instruction.");
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            return BadRequest(ex.Message);
        }
    }
}
