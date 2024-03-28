using CoverGo.Task.Application;
using CoverGo.Task.Domain;
using CoverGo.Task.Domain.Discount.Entities;

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

        public ShoppingCart GetCartById(int id)
        {
            var existingCart = _initialCarts.FirstOrDefault(c => c.Id == id);
            if (existingCart == null)
            {
                throw new Exception("Cart not found");
            }
            return existingCart;
        }

        public decimal CalculateTotalPrice(ShoppingCart cart, DiscountRule discount)
        {
            decimal totalPrice = 0m;

            foreach (var item in cart.Items)
            {
                totalPrice += item.Price * item.Quantity;

                // Check if the current item matches the product ID of the discount rule
                if (item.Id == discount.ProductId)
                {
                    // Calculate how many times the discount should be applied
                    int discountApplies = item.Quantity / discount.DiscountQuantity;

                    // Subtract the discount amount for each time the discount applies
                    totalPrice -= discountApplies * discount.DeductionAmount;
                }
            }

            return totalPrice;
        }

    }
}
