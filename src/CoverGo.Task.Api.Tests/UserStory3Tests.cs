using CoverGo.Task.Domain;
using CoverGo.Task.Infrastructure.Persistence.InMemory;

namespace CoverGo.Task.Api.Tests
{
    public class UserStory3Tests
    {
        private InMemoryProductsRepository _productService;
        private InMemoryShoppingCartRepository _shoppingCartService;

        public UserStory3Tests()
        {
            // Assuming InMemoryProductsRepository and InMemoryShoppingCartRepository are already implemented
            _productService = new InMemoryProductsRepository([]);
            _shoppingCartService = new InMemoryShoppingCartRepository([]);

            // Adding products to the ProductService for testing
            _productService.AddProductAsync(new Product() { Name = "Tennis Ball", Price = 5 });
            _productService.AddProductAsync(new Product() { Name = "Tennis Racket", Price = 20 });
            _productService.AddProductAsync(new Product() { Name = "T-Shirt", Price = 10 });
        }

        [Fact]
        public void CalculateTotalPriceOfShoppingCart_ReturnsCorrectTotalPrice()
        {
            // Arrange
            var shoppingCart = new ShoppingCart() { 
                Id = 1, 
                CartLabel = "Test Cart", 
                Items = [] 
            };
            var tennisBall = new Product() { Id = 1, Name = "Tennis Ball", Price = 5 };
            var tennisRacket = new Product() { Id = 2, Name = "Tennis Racket", Price = 20 };
            var tShirt =new Product() { Id = 3, Name = "T-Shirt", Price = 10 };

            // Act
            _shoppingCartService.AddItemToCart(shoppingCart, tennisBall);
            _shoppingCartService.AddItemToCart(shoppingCart, tennisRacket);
            _shoppingCartService.AddItemToCart(shoppingCart, tShirt);

            var totalPrice = _shoppingCartService.CalculateTotalPrice(shoppingCart , new Domain.Discount.Entities.DiscountRule());

            // Assert
            var expectedTotalPrice = tennisBall.Price + tennisRacket.Price + tShirt.Price;
            Assert.Equal(expectedTotalPrice, totalPrice);
        }
    }
}
