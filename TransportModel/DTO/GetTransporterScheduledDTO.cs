using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportModel.Model.Enum;

namespace TransportModel.DTO
{
    public class GetTransporterScheduledDTO
    {
        public int Id { get; set; }

        public string ClientName { get; set; }
        public string PickupAddress { get; set; }

        public string DeliveryAddress { get; set; }

        
        public Status Status { get; set; }

        public DateTime ScheduledDate { get; set; }

        public List<InstructionProductNameDTO> ProductList { get; set; }    

    }
}
