using CoverGo.Task.Domain;
using CoverGo.Task.Domain.Discount.Entities;
using CoverGo.Task.Infrastructure.Persistence.InMemory;

namespace CoverGo.Task.Api.Tests
{
    public class UserStory4Tests
    {
        private InMemoryProductsRepository _productService;
        private InMemoryShoppingCartRepository _shoppingCartService;
        private InMemoryDiscountRuleRepository _discountRuleService;

        public UserStory4Tests()
        {
            _productService = new InMemoryProductsRepository(new List<Product>());
            _shoppingCartService = new InMemoryShoppingCartRepository(new List<ShoppingCart>());
            _discountRuleService = new InMemoryDiscountRuleRepository(new List<DiscountRule>());

            _productService.AddProductAsync(new Product() { Name = "Tennis Ball", Price = 5 });
            _productService.AddProductAsync(new Product() { Name = "Tennis Racket", Price = 20 });
        }

        [Fact]
        public void CreateDiscount_AddsDiscountSuccessfully()
        {
            // Arrange
            var product = new Product() { Id = 1, Name = "Tennis Ball", Price = 5 };
            var discountRule = new DiscountRule 
            { 
                ProductId = product.Id, 
                DiscountQuantity = 3,
                DeductionAmount = 5
            };

            // Act
            var addedDiscountRule = _discountRuleService.AddDiscountRuleAsync(discountRule);

            // Assert
            Assert.NotNull(addedDiscountRule);
            Assert.Equal(discountRule.ProductId, addedDiscountRule.ProductId);
            Assert.Equal(discountRule.DiscountQuantity, addedDiscountRule.DiscountQuantity);
            Assert.Equal(discountRule.DeductionAmount, addedDiscountRule.DeductionAmount);
        }

        [Fact]
        public void CalculateTotalPriceWithDiscount_ReturnsDiscountedPrice()
        {
            // Arrange
            var shoppingCart = new ShoppingCart() { CartLabel = "Test Cart", Items = new List<Product>() };
            var tennisBall = new Product() { Id = 1, Name = "Tennis Ball", Price = 5 };
            _shoppingCartService.AddItemToCart(shoppingCart, tennisBall);
            _shoppingCartService.AddItemToCart(shoppingCart, tennisBall);
            _shoppingCartService.AddItemToCart(shoppingCart, tennisBall);

            var discountRule = new DiscountRule { ProductId = tennisBall.Id, DiscountQuantity = 3, DeductionAmount = 5 };
            _discountRuleService.AddDiscountRuleAsync(discountRule);

            // Act
            var totalPrice = _shoppingCartService.CalculateTotalPrice(shoppingCart, discountRule);

            // Assert
            var expectedTotalPrice = (tennisBall.Price * 3) - discountRule.DeductionAmount;
            Assert.Equal(expectedTotalPrice, totalPrice);
        }

        [Fact]
        public void CreateDiscountWithMissingProduct_ThrowsException()
        {
            // Arrange
            var discountRule = new DiscountRule { ProductId = -1, DiscountQuantity = 3, DeductionAmount = 5 };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _discountRuleService.AddDiscountRuleAsync(discountRule));
        }

        [Fact]
        public void CreateDiscountWithNonPositiveForEvery_ThrowsException()
        {
            // Arrange
            var product = new Product() { Name = "Tennis Ball", Price = 5 };
            var discountRule = new DiscountRule { ProductId = product.Id, DiscountQuantity = 0, DeductionAmount = 5 };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _discountRuleService.AddDiscountRuleAsync(discountRule));
        }
    }

}
