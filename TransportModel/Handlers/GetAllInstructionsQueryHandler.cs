using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransportModel.Data;
using TransportModel.Queries;
using MediatR;
using TransportModel.DTO;
using TransportModel.Model;

namespace TransportModel.Handlers
{
    public class GetAllInstructionsQueryHandler : IRequestHandler<GetAllInstructionsQuery, IEnumerable<InstructionDTO>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllInstructionsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InstructionDTO>> Handle(GetAllInstructionsQuery request, CancellationToken cancellationToken)
        {
            
            var instructions = await _context.Instruction
                .AsNoTracking() 
                .OrderByDescending(i => i.Id)
                 .Select(c => new InstructionDTO
                 {
                     Id = c.Id,
                     CreatedDate = c.CreatedDate,
                     PickupAddress = c.PickupAddress,
                     DeliveryAddress = c.DeliveryAddress,
                     Status = c.Status,
                     ClientName = _context.Clients.FirstOrDefault(x => x.Id == c.ClientsId).Name,
                 })
                .ToListAsync();

            
            return instructions;
        }
    }
}
