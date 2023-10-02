


using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.Data;
using TransportModel.DTO;
using TransportModel.Model;

namespace TransportModel.Handlers
{
    


    public class UpdateTransporterToInstructionCommandHandler : IRequestHandler<UpdateTransporterToInstructionCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public UpdateTransporterToInstructionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
       // List<InstructionProductUpdateDTO> UpdateDTO = new List<InstructionProductUpdateDTO>();
        public async Task<bool> Handle(UpdateTransporterToInstructionCommand request, CancellationToken cancellationToken)
        {
            foreach (var updateDTO in request.TransporterProducts)
            {
                var instructionProduct = await _context.InstructionProduct.FindAsync(updateDTO.InstructionProductId);

                if (instructionProduct == null)
                {
                    
                    continue;
                }

                if (updateDTO.ScheduledDate.HasValue)
                {
                    instructionProduct.ScheduledDate = updateDTO.ScheduledDate.Value;
                }

                if (updateDTO.TransporterId.HasValue)
                {
                    instructionProduct.TransporterId = updateDTO.TransporterId.Value;
                }
               

                //await _context.SaveChangesAsync(cancellationToken);
            }

            await _context.SaveChangesAsync();
            
            return true;
        }
    }
}

