/*using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransportModel.Data;
using TransportModel.Model;
using TransportModel.Queries;

public class FilterClientsQueryHandler : IRequestHandler<FilterClientsQuery, List<

>>
{
    private readonly ApplicationDbContext _dbContext;

    public FilterClientsQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<
>> Handle(FilterClientsQuery request, CancellationToken cancellationToken)
    {
        var filteredClients = await _dbContext.Clients
            .Where(client => client.Name.Contains(request.FilterText))
            .Select(client => new ClientDto
            {
                Id = client.Id,
                Name = client.Name
            })
            .ToListAsync(cancellationToken); // Use ToListAsync on the IQueryable of Clients, not ClientDto

        return filteredClients;
    }
}
*/