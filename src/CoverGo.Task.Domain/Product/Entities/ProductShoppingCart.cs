

using CoverGo.Task.Domain.ShopppingCart.Entities;

namespace CoverGo.Task.Domain.Product.Entities
{
    public class ProductInShoppingCart
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual required Product Product
        {
            get; set;
        }

        public int QuantityInCart { get; set; }

        public int CartId { get; set; }
        public virtual required ShoppingCart ShoppingCart
        {
            get; set;
        }
    }
}
