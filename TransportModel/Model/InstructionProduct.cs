using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportModel.Model
{
    public class InstructionProduct
    {
        [Key]
        public int InstructionProductId { get; set; }

        [Required(ErrorMessage = "ProductId should not be Empty")]
        [ForeignKey("ProductId")]
        public virtual int ProductId { get; set; }

     

       [Range(1, float.MaxValue,ErrorMessage ="Please select the proper value for Quantity")]
        [Column(TypeName = "decimal(18,6)")]
        [Required(ErrorMessage = "Quantity should not be Empty")]
        public decimal Quantity { get; set; }

        [ForeignKey("InstructionId")]
        [Required(ErrorMessage = "InstructionId should not be Empty")]
        public virtual int InstructionId { get; set; }


        [ForeignKey("TransporterId")]
        public virtual int? TransporterId { get; set; } = null;


        public DateTime? ScheduledDate { get; set; } = null;
       
       // public virtual TransportScheduled TransportScheduled { get; set; }

        //public List<Product> Products { get; set; } 
    }
}
