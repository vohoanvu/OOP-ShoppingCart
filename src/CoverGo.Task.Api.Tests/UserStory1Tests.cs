namespace CoverGo.Task.Api.Tests
{
    public class UserStory1Tests
    {
        [Fact]
        public void AddNewProduct_Successfully()
        {
            // Arrange
            var productService = new ProductService();
            var newProduct = new Product("Tennis Ball", 5);

            // Act
            productService.AddProduct(newProduct);

            // Assert
            var availableProducts = productService.GetAvailableProducts();
            Assert.Contains(newProduct, availableProducts);
        }

        // Test Scenario 2: Create a Product with Missing Name
        [Fact]
        public void AddProduct_MissingName_ThrowsException()
        {
            // Arrange
            var productService = new ProductService();
            var newProduct = new Product("", 5);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => productService.AddProduct(newProduct));
        }

        // Test Scenario 3: Create a Product with Negative Price
        [Fact]
        public void AddProduct_NegativePrice_ThrowsException()
        {
            // Arrange
            var productService = new ProductService();
            var newProduct = new Product("Tennis Ball", -5);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => productService.AddProduct(newProduct));
        }

        // Test Scenario 4: Create a Product with Missing Price
        [Fact]
        public void AddProduct_MissingPrice_ThrowsException()
        {
            // Arrange
            var productService = new ProductService();
            var newProduct = new Product("Tennis Ball", 0); // Assuming 0 is not a valid price

            // Act & Assert
            Assert.Throws<ArgumentException>(() => productService.AddProduct(newProduct));
        }

        // Test Scenario 5: Create a Duplicate Product
        [Fact]
        public void AddProduct_Duplicate_ThrowsException()
        {
            // Arrange
            var productService = new ProductService();
            var existingProduct = new Product("Tennis Ball", 5);
            productService.AddProduct(existingProduct); // Add an existing product
            var duplicateProduct = new Product("Tennis Ball", 5);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => productService.AddProduct(duplicateProduct));
        }
    }
}
