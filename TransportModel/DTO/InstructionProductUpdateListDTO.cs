using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.Model;

namespace TransportModel.DTO
{
    public class InstructionProductUpdateListDTO
    {
        public int InstructionId { get; set; }
        public List<InstructionProductUpdateDTO> TransporterProducts { get; set; } // Pluralized
    }

}
