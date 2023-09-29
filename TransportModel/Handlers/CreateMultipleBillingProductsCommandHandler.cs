/*using MediatR;
using TransportModel.Commands;
using TransportModel.Data;
using TransportModel.Model;

public class CreateMultipleBillingProductsCommandHandler : IRequestHandler<CreateMultipleBillingProductsCommand, List<int>>
{
    private readonly ApplicationDbContext _context;

    public CreateMultipleBillingProductsCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<int>> Handle(CreateMultipleBillingProductsCommand request, CancellationToken cancellationToken)
    {
        var billingProductIds = new List<int>();

        foreach (var billingProductDto in request.BillingProducts)
        {
            var billingProduct = new BillingProduct
            {
                productId = billingProductDto.BillingProductId,
                ProductQuantity = billingProductDto.ProductQuantity,
                InstructionId = billingProductDto.InstructionId,
            };

            _context.BillingProducts.Add(billingProduct);
            await _context.SaveChangesAsync();

            billingProductIds.Add(billingProduct.BillingProductId);
        }

        return billingProductIds;
    }
}
*/