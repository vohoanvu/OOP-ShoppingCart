using CoverGo.Task.Domain;
using CoverGo.Task.Infrastructure.Persistence.InMemory;

namespace CoverGo.Task.Api.Tests
{
    public class UserStory2Tests
    {
        private InMemoryProductsRepository _productService;
        private InMemoryShoppingCartRepository _shoppingCartService;

        public UserStory2Tests()
        {
            // Assuming ProductService and ShoppingCartService are already implemented
            _productService = new InMemoryProductsRepository([]);
            _shoppingCartService = new InMemoryShoppingCartRepository([]);

            // Adding products to the ProductService for testing
            _productService.AddProductAsync(new Product() { Name="Tennis Ball", Price=5 });
            _productService.AddProductAsync(new Product() { Name="Tennis Racket",Price= 20 });
            _productService.AddProductAsync(new Product() {Name="T-Shirt", Price=10 });
        }

        [Fact]
        public void AddItemToShoppingCart_Successfully()
        {
            // Arrange
            var shoppingCart = new ShoppingCart()
            {
                CartLabel = "Test Cart",
                Items = new List<Product>()
            };
            var tennisBall = new Product() { Name="Tennis Ball", Price=5 };

            // Act
            _shoppingCartService.AddItemToCart(shoppingCart, tennisBall);

            // Assert
            Assert.Contains(tennisBall, shoppingCart.Items);
            Assert.True(shoppingCart.Items.Count == 1);
        }

        [Fact]
        public void AddDifferentItemsToShoppingCart_Successfully()
        {
            // Arrange
            var shoppingCart = new ShoppingCart()
            {
                CartLabel = "Test Cart",
                Items = new List<Product>()
            };
            var tennisBall = new Product() { Name="Tennis Ball", Price=5 };
            var tennisRacket = new Product() { Name="Tennis Racket", Price=20 };

            // Act
            _shoppingCartService.AddItemToCart(shoppingCart, tennisBall);
            _shoppingCartService.AddItemToCart(shoppingCart, tennisRacket);

            // Assert
            Assert.Contains(tennisBall, shoppingCart.Items);
            Assert.Contains(tennisRacket, shoppingCart.Items);
            Assert.Equal(2, shoppingCart.Items.Count);
        }

        [Fact]
        public void AddSameItemToShoppingCart_IncreasesQuantity()
        {
            // Arrange
            var shoppingCart = new ShoppingCart()
            {
                CartLabel = "Test Cart",
                Items = new List<Product>()
                {
                    new() { Id=1, Name="Tennis Ball", Price=5 }
                },
            };
            var tennisBall = new Product() { Name="Tennis Ball", Price=5 };

            // Act
            _shoppingCartService.AddItemToCart(shoppingCart, tennisBall);

            // Assert
            Assert.Contains(tennisBall, shoppingCart.Items);
            Assert.Equal(2, shoppingCart.Items.Count);
        }
    }

}
