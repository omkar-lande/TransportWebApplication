using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.Data;

namespace TransportModel.Handlers
{

    public class UpdateTransporterToInstructionCommandHandler : IRequestHandler<UpdateTransporterToInstructionCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;
        private readonly IInstructionDataAcess _instructionDataAccess;

        public UpdateTransporterToInstructionCommandHandler(IMediator mediator,
            ApplicationDbContext context,
            IInstructionDataAcess instructionDataAccess)
        {
            _mediator = mediator;
            _context = context;
            _instructionDataAccess = instructionDataAccess;
        }

        public async Task<bool> Handle(UpdateTransporterToInstructionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var updateDTO in request.TransporterProducts)
                {
                    var instructionProduct = await _context.InstructionProduct.FindAsync(updateDTO.InstructionProductId);

                    if (instructionProduct != null)
                    {
                        // Update instructionProduct properties
                        instructionProduct.ScheduledDate = updateDTO.ScheduledDate.Value;
                        instructionProduct.TransporterId = updateDTO.TransporterId.Value;
                    }
                }

                await _context.SaveChangesAsync();

               

                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

    }

}
    




