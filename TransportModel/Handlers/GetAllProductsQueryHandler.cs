using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Make sure to include Entity Framework Core
using TransportModel.Data;
using TransportModel.DTO;
using TransportModel.Queries;

namespace TransportModel.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDTO>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllProductsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all products from the database
            var products = await _context.Product
                .AsNoTracking() // Optional: Use AsNoTracking for read-only operations
                .Select(p => new ProductDTO
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    ProductDescription = p.Description,
                    ProductPrice = p.Price,
                    // Map other properties as needed
                })
                .ToListAsync();

            return products;
        }
    }
}