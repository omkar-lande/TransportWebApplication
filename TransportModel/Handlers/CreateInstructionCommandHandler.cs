/*using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportModel.Model.Enum;
using TransportModel.Commands;
using TransportModel.Data;
using TransportModel.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using TransportModel.DTO;

namespace TransportModel.Handlers
{


    public class CreateInstructionCommandHandler : IRequestHandler<CreateInstrucionCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateInstructionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateInstrucionCommand request, CancellationToken cancellationToken)
        {
            var newInstruction = new InstructionDTO
            {
                // Populate properties from the request
                InstructionDate = request.Instruction.InstructionDate,
                PickupAddress = request.Instruction.PickupAddress,
                DeliveryAddress = request.Instruction.DeliveryAddress,
                ClientId = request.Instruction.ClientId,
                ProductList = request.Instruction.ProductList
            };

            List<BillingProduct> billingProducts = new List<BillingProduct>();

            foreach (var product in request.Instruction.ProductList)
            {
                BillingProduct billingProduct = new BillingProduct();
                billingProduct.productId = product.ProductId;
                billingProduct.ProductQuantity = product.ProductQuantity;
                billingProducts.Add(billingProduct);
            }

            Instruction instruction = new Instruction()
            {
                InstructionDate = request.Instruction.InstructionDate,
                PickupAddress = request.Instruction.PickupAddress,
                DeliveryAddress = request.Instruction.DeliveryAddress,
                ClientId = request.Instruction.ClientId,
                ProductList = billingProducts,
            };           


            _context.Instructions.Add(instruction);

            await _context.SaveChangesAsync();

            // Return the newly created instruction's ID
            return instruction.InstructionId;
        }
    }

}
*/

/*
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using TransportModel.Commands;
using TransportModel.Data;
using TransportModel.DTO;
using TransportModel.Model;


namespace Transport.API.Handler
{
    public class CreateInstructionCommandHandler : IRequestHandler<CreateInstrucionCommand, int>
    {
        private readonly ApplicationDbContext  _context;

        public CreateInstructionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateInstrucionCommand request, CancellationToken cancellationToken)
        {
            var newInstruction = new InstructionDTO
            {
                // Populate properties from the request
                CreatedDate = request.Instruction.CreatedDate,
                PickupAddress = request.Instruction.PickupAddress,
                DeliveryAddress = request.Instruction.DeliveryAddress,
                ClientName = request.Instruction.ClientName,
                ProductList = request.Instruction.ProductList
            };
            List<InstructionProduct> billingProducts = new List<InstructionProduct>();

            foreach (var product in request.Instruction.ProductList)
            {
                InstructionProduct billingProduct = new InstructionProduct();
                billingProduct.ProductId = product.ProductId;
                billingProduct.Quantity = product.ProductQuantity;
                billingProduct.InstructionId = product.InstructionId;
                billingProducts.Add(billingProduct);
            }

            //  _context.Instruction.Add(instruction);

            //  await _context.SaveChangesAsync();

            // Return the newly created instruction's ID
              return newInstruction.Id;

            
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
                    billingProduct.TransporterId = null;


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

        /* private async Task<int?> GetClientIdByClientName(string clientName)
         {
             // Implement the logic to retrieve the client ID based on the client name
             var client = await _context.Clients.FirstOrDefaultAsync(c => c.Name == clientName);
             return client?.Id;
         }

    }
}
*/

using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.Data;
using TransportModel.DTO;
using TransportModel.Model;

namespace TransportWebApplication2.Controllers
{
  
    public class CreateInstructionCommandHandler : IRequestHandler<CreateInstrucionCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;
        private readonly IInstructionDataAcess _instructionDataAccess;

        public CreateInstructionCommandHandler(
            IMediator mediator,
            ApplicationDbContext context,
            IInstructionDataAcess instructionDataAccess)
        {
            _mediator = mediator;
            _context = context;
            _instructionDataAccess = instructionDataAccess;
        }

        public async Task<int> Handle(CreateInstrucionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<InstructionProduct> billingProducts = new List<InstructionProduct>();

                foreach (var product in request.Instruction.ProductList)
                {
                    InstructionProduct billingProduct = new InstructionProduct();
                    billingProduct.ProductId = product.ProductId;
                    billingProduct.Quantity = product.Quantity;
                    billingProduct.InstructionId = product.InstructionId;
                    billingProduct.ScheduledDate = null;
                    billingProduct.TransporterId = null;

                    billingProducts.Add(billingProduct);
                }

                Instruction instruction = new Instruction()
                {
                    CreatedDate = request.Instruction.CreatedDate,
                    PickupAddress = request.Instruction.PickupAddress,
                    DeliveryAddress = request.Instruction.DeliveryAddress,
                    ClientsId = request.Instruction.ClientsId,
                    instructionProducts = billingProducts,
                    Status = TransportModel.Model.Enum.Status.Pending,
                };

                _context.Instruction.Add(instruction);
                await _context.SaveChangesAsync();

                return instruction.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

     
    }
}


