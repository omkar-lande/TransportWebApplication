using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.Data;
using TransportModel.DTO;
using TransportModel.Model;
using TransportModel.Queries;

namespace TransportModel.Handlers
{
    public class GetAllTransporterQueryHandler : IRequestHandler<GetAllTransporterQuery, List<TransporterDTO>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllTransporterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<TransporterDTO>> Handle(GetAllTransporterQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all clients from the database
            var Transporter = await _context.Transporters
                .AsNoTracking() // Optional: Use AsNoTracking for read-only operations
                .Select(c => new TransporterDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    // Map other properties as needed
                })
                .ToListAsync();

            return Transporter;
        }
    }
}
