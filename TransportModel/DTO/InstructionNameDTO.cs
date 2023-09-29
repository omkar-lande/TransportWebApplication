﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportModel.Model.Enum;
using TransportModel.Model;

namespace TransportModel.DTO
{
    public class InstructionNameDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } 

        public string ClientName { get; set; }

        public string PickupAddress { get; set; }

        public string DeliveryAddress { get; set; }

        public Status Status { get; set; } = Status.Pending;
        public List<InstructionProductNameDTO> ProductList { get; set; }
    }
}
