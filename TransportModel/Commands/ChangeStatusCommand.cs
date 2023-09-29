using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.DTO;

namespace TransportModel.Commands
{
    public class ChangeStatusCommand : IRequest<bool>
    {
        public int instructionid { get; set; }

        public ChangeStatusDTO ChangeStatusDTO { get; set; }
    }

}


