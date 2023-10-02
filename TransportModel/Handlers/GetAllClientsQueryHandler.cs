using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.Data;
using TransportModel.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransportModel.DTO;

namespace TransportModel.Handlers
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, List<ClientDTO>>
    {
        private readonly ApplicationDbContext _context;


        public GetAllClientsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClientDTO>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all clients from the database
            var clients = await _context.Clients
                .AsNoTracking() 
                .Select(c => new ClientDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                   
                })
                .ToListAsync();

            return clients;
        }
    }
}
