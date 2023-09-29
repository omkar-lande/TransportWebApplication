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
    public class CreateInstructionRequest
    {


        public DateTime InstructionDate { get; set; } = DateTime.Now;


        public string ClientName { get; set; }


        public string PickupAddress { get; set; }


        public string DeliveryAddress { get; set; }


        public required int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Clients ClientList { get; set; }


        public Status Status { get; set; } = Status.Pending;
    }
}
*/