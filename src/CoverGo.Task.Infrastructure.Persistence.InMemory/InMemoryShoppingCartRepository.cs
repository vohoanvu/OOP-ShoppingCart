using CoverGo.Task.Application;
using CoverGo.Task.Domain;

namespace CoverGo.Task.Infrastructure.Persistence.InMemory
{
    public class InMemoryShoppingCartRepository : IShoppingCartQuery, IShoppingCartWriteRepository
    {
        private List<ShoppingCart> _initialCarts;

        public InMemoryShoppingCartRepository(List<ShoppingCart> initialCart)
        {
            _initialCarts = initialCart;
        }

        public void AddItemToCart(ShoppingCart cart, Product product)
        {
            var existingProduct = cart.Items.FirstOrDefault(p => p.Name == product.Name);
            if (existingProduct != null)
            {
                // If the product already exists in the cart, increase the quantity
                existingProduct.Quantity++;
            }
            else
            {
                // If the product does not exist in the cart, add it with a quantity of 1
                cart.Items.Add(product);
            }
        }
    }
}
