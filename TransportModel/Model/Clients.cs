using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportModel.Model.Enum;

namespace TransportModel.Model
{
    public class Clients

    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Clients Name should not be Empty.")]
        public string Name { get; set; }
        public virtual List<Instruction> Instruction { get; set; }
    }
}
