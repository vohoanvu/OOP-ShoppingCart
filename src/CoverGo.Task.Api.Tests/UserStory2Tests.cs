using CoverGo.Task.Infrastructure.Persistence.InMemory;

namespace CoverGo.Task.Api.Tests
{
    public class UserStory2Tests
    {
        private InMemoryProductsRepository _productService;
        private ShoppingCartService _shoppingCartService;

        public UserStory2Tests()
        {
            // Assuming ProductService and ShoppingCartService are already implemented
            _productService = new ProductService();
            _shoppingCartService = new ShoppingCartService();

            // Adding products to the ProductService for testing
            _productService.AddProduct(new Product("Tennis Ball", 5));
            _productService.AddProduct(new Product("Tennis Racket", 20));
            _productService.AddProduct(new Product("T-Shirt", 10));
        }

        [Fact]
        public void AddItemToShoppingCart_Successfully()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var tennisBall = _productService.GetProductByName("Tennis Ball");

            // Act
            _shoppingCartService.AddItemToCart(shoppingCart, tennisBall!, 1);

            // Assert
            Assert.Contains(tennisBall, shoppingCart.Items);
            Assert.Equal(1, shoppingCart.Quantity);
        }

        [Fact]
        public void AddDifferentItemsToShoppingCart_Successfully()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var tennisBall = _productService.GetProductByName("Tennis Ball");
            var tennisRacket = _productService.GetProductByName("Tennis Racket");

            // Act
            _shoppingCartService.AddItemToCart(shoppingCart, tennisBall!, 1);
            _shoppingCartService.AddItemToCart(shoppingCart, tennisRacket!, 1);

            // Assert
            Assert.Contains(tennisBall, shoppingCart.Items);
            Assert.Contains(tennisRacket, shoppingCart.Items);
            Assert.Equal(1, shoppingCart.Quantity);
            Assert.Equal(1, shoppingCart.Quantity);
        }

        [Fact]
        public void AddSameItemToShoppingCart_IncreasesQuantity()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var tennisBall = _productService.GetProductByName("Tennis Ball");

            // Act
            _shoppingCartService.AddItemToCart(shoppingCart, tennisBall!, 1);
            _shoppingCartService.AddItemToCart(shoppingCart, tennisBall!, 1);

            // Assert
            Assert.Contains(tennisBall, shoppingCart.Items);
            Assert.Equal(2, shoppingCart.Quantity);
        }

        [Fact]
        public void AddNonExistingProductToCart_ThrowsException()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var nonExistingProduct = new Product("Non-Existing Product", 5);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _shoppingCartService.AddItemToCart(shoppingCart, nonExistingProduct, 1));
        }
    }

}
