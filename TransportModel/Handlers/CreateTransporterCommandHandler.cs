/*using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.Data;
using TransportModel.DTO;
using TransportModel.Model;


namespace TransportModel.Handlers
{
    public class CreateTransporterCommandHandler : IRequestHandler<CreateTransporterCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public CreateTransporterCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTransporterCommand request, CancellationToken cancellationToken)
        {
            var newTransporterScheduled = new TransporterScheduledDTO
            {
                // Populate properties from the request
                InstructionProductId = request.TransporterScheduled.InstructionProductId,
                TransporterId = request.TransporterScheduled.TransporterId,
                ScheduledDate = request.TransporterScheduled.ScheduledDate,
            };
           
            TransportScheduled transportScheuled = new TransportScheduled()
            {
                InstructionProductId = newTransporterScheduled.InstructionProductId,
                TransporterId = newTransporterScheduled.TransporterId,
                ScheduledDate = newTransporterScheduled.ScheduledDate,
            };


            //  _context.Instruction.Add(instruction);

            //  await _context.SaveChangesAsync();

            // Return the newly created instruction's ID
            return transportScheuled.Id;


        }
    }
}





public class AddTransporterToInstructionProductCommandHandler
{
    private readonly YourDbContext _context;

    public AddTransporterToInstructionProductCommandHandler(YourDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(AddTransporterToInstructionProductCommand request, CancellationToken cancellationToken)
    {
        var instructionProduct = await _context.InstructionProducts.FindAsync(request.InstructionProductId);

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
*/