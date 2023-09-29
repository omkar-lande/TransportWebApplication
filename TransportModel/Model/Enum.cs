using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TransportModel.Model
{
    public class Enum
    {

        public enum Status
        {
            Pending,
            Scheduled,
            InProgress,
            Delivered,
            Invoiced
        }

        public enum IsActive
        {
            yes,
            No
        }

        public enum IsDeleted
        {
            Yes,
            No
        }
    }
}
