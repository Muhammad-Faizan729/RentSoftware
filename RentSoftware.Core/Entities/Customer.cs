
namespace RentSoftware.Core.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public ICollection<Rent> Rents { get; set; }
    }
}
