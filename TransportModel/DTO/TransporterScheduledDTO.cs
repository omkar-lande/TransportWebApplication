using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportModel.DTO
{
    public class TransporterScheduledDTO
    {

        public DateTime? ScheduledDate { get; set; }
        public int? TransporterId { get; set; }
    }
}
