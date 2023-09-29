using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.DTO;
using TransportModel.Model;

namespace TransportModel.Queries
{
    public class GetAllTransporterQuery : IRequest<List<TransporterDTO>>
    {
    }
}
