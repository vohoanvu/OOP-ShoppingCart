using CoverGo.Task.Domain.Product.Entities;
using CoverGo.Task.Infrastructure.Persistence.InMemory;

namespace CoverGo.Task.Api.Tests
{
    public class UserStory1Tests
    {
        [Fact]
        public async ValueTask AddFirstProduct_Successfully()
        {
            // Arrange
            var productService = new InMemoryProductsRepository([]);
            var newProduct = new Product()
            {
                Name = "Tennis Ball",
                Price = 5
            };

            // Act
            await productService.AddProductAsync(newProduct);

            // Assert
            var availableProducts = await productService.GetProductsAsync();
            Assert.Contains(newProduct, availableProducts);
        }

        [Fact]
        public async ValueTask AddSecondProduct_Successfully()
        {
            // Arrange
            var existingProducts = new List<Product>()
            {
                new() { Name="Tennis Ball", Price = 5 }
            };
            var productService = new InMemoryProductsRepository(existingProducts);
            var newProduct = new Product()
            {
                Name = "Tennis Ball",
                Price = 5
            };

            // Act
            await productService.AddProductAsync(newProduct);

            // Assert
            var availableProducts = await productService.GetProductsAsync();
            Assert.Contains(newProduct, availableProducts);
            Assert.Contains(existingProducts.First(), availableProducts);
        }

        // Test Scenario 2: Create a Product with Missing Name
        [Fact]
        public void AddProduct_MissingName_ThrowsException()
        {
            // Arrange
            var productService = new InMemoryProductsRepository([]);
            var newProduct = new Product() { Name="", Price=5 };

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => {
                await productService.AddProductAsync(newProduct);
                var availableProducts = await productService.GetProductsAsync();
                Assert.Empty(availableProducts);
            });
        }

        // Test Scenario 3: Create a Product with Negative Price
        [Fact]
        public void AddProduct_NegativePrice_ThrowsException()
        {
            // Arrange
            var productService = new InMemoryProductsRepository([]);
            var newProduct = new Product() {Name="Tennis Ball", Price=-5 };

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => {
                await productService.AddProductAsync(newProduct);
                var availableProducts = await productService.GetProductsAsync();
                Assert.Empty(availableProducts);
            });
        }
    }
}
