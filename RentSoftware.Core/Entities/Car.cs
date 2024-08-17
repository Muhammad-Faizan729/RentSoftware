
namespace RentSoftware.Core.Entities
{
    public class Car
    {
        public int CarId { get; set; }

        public string CarModel { get; set; }

        public ICollection<Rent> Rents { get; set; }
    }
}
