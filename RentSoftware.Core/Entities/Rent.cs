using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentSoftware.Core.Entities
{
    public class Rent
    {
        public int RentId { get; set; }

        public DateTime RentDate { get; set; }

        public Agent Agent { get; set; }

        public Car Car { get; set; }

        public Customer Customer { get; set; }

        public int AgentId { get; set; }

        public int CustomerId { get; set; }

        public int CarId { get; set; }
    }
}
