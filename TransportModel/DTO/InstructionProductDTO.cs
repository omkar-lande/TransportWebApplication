using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportModel.DTO
{
    public class InstructionProductDTO
    {
        public int InstructionProductId { get; set; }
        public int ProductId { get; set; }

       // public string ProductName { get; set; }
        public decimal ProductQuantity { get; set; }
        public int InstructionId { get; set; }

       // public int TransporterId { get; set; }
    }
}
