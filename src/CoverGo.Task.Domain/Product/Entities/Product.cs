using System.Text.Json.Serialization;

namespace CoverGo.Task.Domain
{
    public class Product
    {
        [JsonIgnore]
        public int Id { get; set; }

        public required string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
