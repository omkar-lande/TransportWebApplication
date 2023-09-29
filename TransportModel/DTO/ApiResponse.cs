using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportModel.DTO
{
    public class ApiResponse <T>
    {
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
