using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.DTO;

namespace TransportModel.Queries
{
    public class GetAllProductsQuery :IRequest<List<ProductDTO>>
    {
    }
}
