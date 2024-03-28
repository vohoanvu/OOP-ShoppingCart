using CoverGo.Task.Domain;
using CoverGo.Task.Domain.Discount.Entities;

namespace CoverGo.Task.Application
{
    public interface IShoppingCartQuery
    {
        public ShoppingCart GetCartById(int id);

        public decimal CalculateTotalPrice(ShoppingCart cart, DiscountRule discount);
    }
}
