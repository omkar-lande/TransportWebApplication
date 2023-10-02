using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.DTO;

namespace TransportModel.Commands
{
    public class UpdateTransporterToInstructionCommand : IRequest<bool>
    {
        public int InstructionId { get; set; }
        public List<InstructionProductUpdateDTO> TransporterProducts { get; set; } 
   
    }

}
