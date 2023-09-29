/*using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransportModel.Data;
using TransportModel.DTO; // Make sure you have the necessary using directive for ProductDto
using TransportModel.Queries;

public class FilterProductsQueryHandler : IRequestHandler<FilterProductQuery, List<ProductDTO>>
{
    private readonly ApplicationDbContext _dbContext;

    public FilterProductsQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductDTO>> Handle(FilterProductQuery request, CancellationToken cancellationToken)
    {
        var filteredProducts = await _dbContext.Product
            .Where(product => product.Name.Contains(request.FilterText))
            .Select(product => new ProductDTO // Corrected from 
to ProductDto
            {
                ProductId = product.Id,
                ProductName = product.Name
            })
            .ToListAsync(cancellationToken);

        return filteredProducts;
    }
}
*/