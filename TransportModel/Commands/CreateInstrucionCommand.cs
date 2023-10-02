
using MediatR;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.DTO;
using TransportModel.Model;

namespace TransportModel.Commands
{
    public class CreateInstrucionCommand : IRequest<int>
    {
         public CreateInstructionDTO Instruction { get; set; }
      

    }
}
