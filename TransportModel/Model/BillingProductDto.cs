﻿/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportModel.Model
{
    public class BillingProductDto
    {
        [Key]
        public int BillingProductId { get; set; }

        // public string BillingProductName { get; set; }

        [ForeignKey("productList")]
        public int productId { get; set; }
        public Product Product { get; set; }

        //  public string ProductName {get; set; 

        [Range(0, float.MaxValue)]
        [Column(TypeName = "decimal(18,6)")]
        public decimal ProductQuantity { get; set; }

        [ForeignKey("InstructionId")]
        public int InstructionId { get; set; }
        public Instruction Instruction { get; set; }    
    }

}
*/