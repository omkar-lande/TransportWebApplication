using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.Model;
using MediatR;
using TransportModel.DTO;

namespace TransportModel.Queries
{
    public class GetAllInstructionsQuery : IRequest<IEnumerable<InstructionDTO>>
    {
    }
}
