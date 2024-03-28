﻿namespace CoverGo.Task.Domain.Product.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public virtual List<ProductInShoppingCart>? ProductInCarts { get; set; }
    }
}
