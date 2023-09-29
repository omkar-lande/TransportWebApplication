/*using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.Data;

namespace TransportModel.Handlers
{
    public class AddTransporterToInstructionProductCommandHandler : IRequestHandler<AddTransporterToInstructionProductCommand, bool>
    {

        private readonly ApplicationDbContext _context;

        public AddTransporterToInstructionProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddTransporterToInstructionProductCommand request, CancellationToken cancellationToken)
        {
            var instructionProduct = await _context.InstructionProduct.FindAsync(request.InstructionProductId);

            if (instructionProduct == null)
            {
                // Handle the case where the instruction product is not found
                return false;
            }

            // Update the fields based on the DTO values
            if (request.UpdateDTO.ScheduledDate.HasValue)
            {
                instructionProduct.ScheduledDate = request.UpdateDTO.ScheduledDate.Value;
            }
            

            if (request.UpdateDTO.TransporterId.HasValue)
            {
                instructionProduct.TransporterId = request.UpdateDTO.TransporterId.Value;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
*/


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
    //public class UpdateTransporterToInstructionProductCommand : IRequest<bool>
    //{
    //  // public List<InstructionProductUpdateDTO> UpdateDTOs { get; set; }
    //   public List<InstructionProductUpdateDTO> UpdateDTO = new List<InstructionProductUpdateDTO>();
    //}


    public class AddTransporterToInstructionProductCommandHandler : IRequestHandler<AddTransporterToInstructionProductCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public AddTransporterToInstructionProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
       // List<InstructionProductUpdateDTO> UpdateDTO = new List<InstructionProductUpdateDTO>();
        public async Task<bool> Handle(AddTransporterToInstructionProductCommand request, CancellationToken cancellationToken)
        {
            foreach (var updateDTO in request.TransporterProducts)
            {
                var instructionProduct = await _context.InstructionProduct.FindAsync(updateDTO.InstructionProductId);

                if (instructionProduct == null)
                {
                    // Handle the case where the instruction product is not found
                    // You can choose to skip or log this particular update
                    continue;
                }

                // Update the fields based on the DTO values
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

