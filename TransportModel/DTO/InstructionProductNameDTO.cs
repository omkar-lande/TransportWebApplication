using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportModel.DTO
{
    public class InstructionProductNameDTO
    {
        public int InstructionProductId { get; set; }
         public string ProductName { get; set; }
        public decimal ProductQuantity { get; set; }

        public  string ProductDescription {get; set;}

        public decimal ProductPrice { get; set;}

        public int InstructionId { get; set; }

        public DateTime? ScheduledDate { get; set; } 
      
       public string TransporterName { get; set; } 
    }
}
