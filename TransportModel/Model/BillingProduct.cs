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
    public class BillingProduct
    {
        [Key]
        public int BillingProductId { get; set; }

       // public string BillingProductName { get; set; }

        [ForeignKey("productList")]
        public int productId { get; set; }
        public Product Product { get; set; }

        //  public string ProductName {get; set; }  





        [Range(0, float.MaxValue)]
        [Column(TypeName = "decimal(18,6)")]
        public decimal ProductQuantity { get; set; }

        public int InstructionId { get; set; }
        [ForeignKey("InstructionId")]
        public Instruction Instruction { get; set; }



         public IsActiveEnum IsActive { get; set; }

         public IsDeletedEnum IsDeleted { get; set; }
         [Required]
         public required string CreatedBy { get; set; }

         public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
         [Required]
         public required string ModifiedBy { get; set; }

         public DateTimeOffset ModifiedDate { get; set; } = DateTimeOffset.UtcNow;
         [Required]
         public required string ModifiedIpConfig { get; set; } 
    }
}
*/
