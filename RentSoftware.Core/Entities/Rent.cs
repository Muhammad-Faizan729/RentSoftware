using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentSoftware.Core.Entities
{
    public class Rent
    {
        [Key] // Explicitly mark this as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // This ensures the database will generate the ID
        public int RentId { get; set; }

        [Required]
        public DateTime RentDate { get; set; }

        public Agent Agent { get; set; }

        public Car Car { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public int AgentId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int CarId { get; set; }
    }
}
