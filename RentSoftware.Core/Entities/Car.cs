
using System.Text.Json.Serialization;

namespace RentSoftware.Core.Entities
{
    public class Car
    {
        public int CarId { get; set; }

        public string CarModel { get; set; }

        [JsonIgnore]
        public ICollection<Rent>? Rents { get; set; }
    }
}
