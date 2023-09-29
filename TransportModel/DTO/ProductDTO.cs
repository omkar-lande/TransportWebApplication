using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportModel.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public required string ProductName { get; set; }

        public string ProductDescription { get; set; }  

        public decimal ProductPrice { get; set; }   
    }
}
