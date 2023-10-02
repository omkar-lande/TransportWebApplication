

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

namespace TransportWebApplication.Controllers
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


