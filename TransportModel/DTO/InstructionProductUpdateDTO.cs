using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportModel.DTO
{
    public class InstructionProductUpdateDTO
    {
        public int InstructionProductId { get; set; }
        public DateTime? ScheduledDate { get; set; }
        [Required(ErrorMessage ="Transporter Id should not be Empty")]
        public int? TransporterId { get; set; }
    }
}
