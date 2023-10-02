


using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.Data;
using TransportModel.DTO;
using TransportModel.Model;
using TransportModel.Queries;

namespace TransportModel.Handlers
{
    public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, bool>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public ChangeStatusCommandHandler(ApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<bool> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var pendingInstructions = await _context.Instruction
                      .FirstOrDefaultAsync(i => i.Status == Model.Enum.Status.Pending && i.Id== request.instructionid);

                var updatedInstructions = new ChangeStatusDTO();


                if(pendingInstructions==null)
                {
                    return false;
                }
           
                var productQuery = new GetInstructionProductQuery { Id = pendingInstructions.Id };
                var productList = await _mediator.Send(productQuery);

                // Check if all products have non-null and non-zero TransporterId
                bool allProductsScheduled = productList.All(p => p.TransporterName != null);

                if (allProductsScheduled)
                {
                    // Update instruction status to "Scheduled" in the database
                    pendingInstructions.Status = Model.Enum.Status.Scheduled;
                    _context.Entry(pendingInstructions).State = EntityState.Modified;

                }
            

            // Save changes to the database
            await _context.SaveChangesAsync();

            return true;
        }
    }
}



