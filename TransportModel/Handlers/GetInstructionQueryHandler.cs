using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransportModel.Data;
using TransportModel.Model;
using TransportModel.Queries;
using TransportModel.DTO;

namespace TransportModel.Handlers
{
    public class GetInstructionQueryHandler : IRequestHandler<GetInstructionQuery, InstructionNameDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public GetInstructionQueryHandler(ApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<InstructionNameDTO> Handle(GetInstructionQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the instruction by ID from the database
            var instruction = await _context.Instruction
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == request.Id);

            if (instruction == null)
            {

                throw new Exception("Instruction not found for the provided ID.");
            }

            var instructionProducts = await _mediator.Send(new GetInstructionProductQuery { Id = request.Id });

            var instructionModel = new InstructionNameDTO
            {
                CreatedDate = instruction.CreatedDate,
                PickupAddress = instruction.PickupAddress,
                DeliveryAddress = instruction.DeliveryAddress,
                ClientName = _context.Clients.FirstOrDefault(x => x.Id == instruction.ClientsId)?.Name,
                Status = instruction.Status,
                ProductList = instructionProducts
            };

            return instructionModel;
        }
    }
}
