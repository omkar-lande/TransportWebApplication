using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.DTO;

namespace TransportModel.Commands
{
    public class CreateTransporterCommand : IRequest<bool>
    {
        public int InstructionProductId { get; set; }
        public TransporterScheduledDTO UpdateDTO { get; set; }
    }
}



    