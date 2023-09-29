/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportModel.Model.Enum;

namespace TransportModel.Model
{
    public class TransportScheduled

    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("InstructionProductId")]
        public virtual int InstructionProductId { get; set; }

        [ForeignKey("TransporterId")]
        public virtual int TransporterId { get; set;}

        public DateTime ScheduledDate { get; set; }
        

    }
}

*/