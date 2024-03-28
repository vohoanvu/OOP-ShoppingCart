using System.ComponentModel.DataAnnotations;

namespace CoverGo.Task.Domain
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public virtual required List<ProductInShoppingCart> ProductInCarts { get; set; }
    }
}
