using CoverGo.Task.Domain;

namespace CoverGo.Task.Application
{
    public interface IShoppingCartWriteRepository
    {
        public ShoppingCart AddItemToCart(ShoppingCart cart, Product item);
    }
}
