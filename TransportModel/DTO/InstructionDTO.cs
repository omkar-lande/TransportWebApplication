using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportModel.Model.Enum;
using TransportModel.Model;

namespace TransportModel.DTO
{
    public class InstructionDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string ClientName { get; set; }

        public string PickupAddress { get; set; }

        public string DeliveryAddress { get; set; }
       
        public Status Status { get; set; } = Status.Pending;
        public List<InstructionProductDTO> ProductList { get; set; }
    }
}
