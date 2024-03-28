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

        public ShoppingCart AddItemToCart(ShoppingCart cart, Product item)
        {
            cart.Items.Add(item);
            return cart;
        }
    }
}
