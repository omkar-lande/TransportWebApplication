/*using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransportModel.Data;
using TransportModel.Model;
using TransportModel.Queries;
using MediatR;

namespace TransportModel.Handlers
{
    public class SearchInstructionsQueryHandler : IRequestHandler<SearchInstructionsQuery, IEnumerable<Instruction>>
    {
        private readonly ApplicationDbContext _context;

        public SearchInstructionsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Instruction>> Handle(SearchInstructionsQuery request, CancellationToken cancellationToken)
        {
            // Perform the search in the database based on the search term
            var instructions = await _context.Instructions
                .AsNoTracking()
                .Where(i => i.ClientName.Contains(request.SearchTerm))
                .OrderByDescending(i => i.InstructionId)// You can customize the search criteria as needed
                .ToListAsync();

            return instructions;
        }
    }
}
*/