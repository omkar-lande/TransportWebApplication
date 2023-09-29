using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportModel.Model.Enum;
using TransportModel.Model;
using System.ComponentModel.DataAnnotations;

namespace TransportModel.DTO
{
    public class CreateInstructionDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } 

        public int ClientsId { get; set; }
        [Required(ErrorMessage ="pickup Address cannot be Empty")]
        public string PickupAddress { get; set; }
        [Required(ErrorMessage = "Delivery Address cannot be Empty")]
        public string DeliveryAddress { get; set; }

        public Status Status { get; set; } = Status.Pending;
        public List<InstructionProduct> ProductList { get; set; }
    }
}
