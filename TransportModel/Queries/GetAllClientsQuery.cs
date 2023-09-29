using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TransportModel.DTO;

namespace TransportModel.Queries
{
    public class GetAllClientsQuery: IRequest<List<ClientDTO>>
    {
    }
}
