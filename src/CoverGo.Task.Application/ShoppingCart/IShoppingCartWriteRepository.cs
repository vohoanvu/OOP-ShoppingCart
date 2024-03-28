using CoverGo.Task.Domain;

namespace CoverGo.Task.Application
{
    public interface IShoppingCartWriteRepository
    {
        public void AddItemToCart(ShoppingCart cart, Product item);
    }
}
