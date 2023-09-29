using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportModel.Model.Enum;
using TransportModel.DTO;

namespace TransportModel.Model
{
    public class Instruction
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage ="Pickup Adress Should not be Empty.")]
        public string PickupAddress { get; set; }
        [Required(ErrorMessage = "Delivery Adress Should not be Empty.")]
        public string DeliveryAddress { get; set; }

        public Status Status { set; get; } = Status.Pending;

        [ForeignKey("ClientsId")]
        public virtual int ClientsId { get; set; }
        public virtual List<InstructionProduct> instructionProducts { get; set; }
    }
}
