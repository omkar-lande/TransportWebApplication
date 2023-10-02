using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 
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
            
            var products = await _context.Product
                .AsNoTracking() 
                .Select(p => new ProductDTO
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    ProductDescription = p.Description,
                    ProductPrice = p.Price,
                    
                })
                .ToListAsync();

            return products;
        }
    }
}