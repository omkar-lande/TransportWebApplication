﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportModel.Model.Enum;

namespace TransportModel.Model
{
    public class Transporter
    {

        [Key]
        public int Id { get; set; }
        public  string Name { get; set; }

        public virtual List<InstructionProduct> InstructionProduct { get; set; }
    }
}
