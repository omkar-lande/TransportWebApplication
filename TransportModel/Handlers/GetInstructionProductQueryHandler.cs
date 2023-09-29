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
    public class GetInstructionProductQueryHandler : IRequestHandler<GetInstructionProductQuery, List<InstructionProductNameDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetInstructionProductQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<InstructionProductNameDTO>> Handle(GetInstructionProductQuery request, CancellationToken cancellationToken)
        {

            var filteredInstructionProduct = await _dbContext.InstructionProduct
                .Where(c => c.InstructionId==request.Id)
                .Select(InstructionProduct => new InstructionProductNameDTO
                {
                    InstructionId = request.Id,
                    InstructionProductId = InstructionProduct.InstructionProductId,                    
                   // ProductId = InstructionProduct.ProductId,
                    ProductName = _dbContext.Product.FirstOrDefault(x => x.Id == InstructionProduct.ProductId).Name,
                    ProductQuantity = InstructionProduct.Quantity,
                    ProductPrice=_dbContext.Product.FirstOrDefault(x => x.Id == InstructionProduct.ProductId).Price,
                    ProductDescription = _dbContext.Product.FirstOrDefault(x => x.Id == InstructionProduct.ProductId).Description,
                    TransporterName= _dbContext.Transporters.FirstOrDefault(x => x.Id == InstructionProduct.TransporterId).Name,
                   ScheduledDate=InstructionProduct.ScheduledDate,
                    //TransporterName=_dbContext.Transporters.FirstOrDefault(x=> x.Id== InstructionProduct.InstructionProductId).Name,
                    //TransporterName = _dbContext.Transporters.FirstOrDefault(t => t.Id == InstructionProduct.)?.Name



                    //InstructionProductId = InstructionProduct.InstructionProductId,
                    //ProductId = InstructionProduct.ProductId,
                    // Quantity= InstructionProduct.Quantity,

                })
                .ToListAsync(cancellationToken); 

            return filteredInstructionProduct;
        }
    }
}
