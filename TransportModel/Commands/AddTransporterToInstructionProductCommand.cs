using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.DTO;

namespace TransportModel.Commands
{
    public class AddTransporterToInstructionProductCommand : IRequest<bool>
    {
        /* InstructionProductUpdateDTO singleProduct = new InstructionProductUpdateDTO();
         List<InstructionProductUpdateDTO> productList = new List<InstructionProductUpdateDTO>();
         productList.Add(singleProduct);
        */

        public InstructionProductUpdateDTO UpdateDTO { get; set; }
        public List<InstructionProductUpdateDTO> UpdateDTOs { get; set; } // Pluralized
    }

}
