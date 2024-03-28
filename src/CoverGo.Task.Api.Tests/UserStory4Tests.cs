namespace CoverGo.Task.Api.Tests
{
    public class UserStory4Tests
    {
        private ProductService _productService;
        private ShoppingCartService _shoppingCartService;
        private DiscountService _discountService;

        public UserStory4Tests()
        {
            // Assuming ProductService, ShoppingCartService, and DiscountService are already implemented
            _productService = new ProductService();
            _shoppingCartService = new ShoppingCartService();
            _discountService = new DiscountService();

            // Adding products to the ProductService for testing
            _productService.AddProduct(new Product("Tennis Ball", 5));
            _productService.AddProduct(new Product("Tennis Racket", 20));
            _productService.AddProduct(new Product("T-Shirt", 10));
        }

        [Fact]
        public void CreateDiscount_AddsDiscountSuccessfully()
        {
            // Arrange
            var tShirt = _productService.GetProductByName("T-Shirt");

            // Act
            _discountService.CreateItemDiscount(tShirt!, 3);

            // Assert
            Assert.True(_discountService.IsDiscountApplied(tShirt!));
        }

        [Fact]
        public void CalculateTotalPriceWithDiscount_ReturnsDiscountedPrice()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var tennisBall = _productService.GetProductByName("Tennis Ball");
            var tennisRacket = _productService.GetProductByName("Tennis Racket");
            var tShirt = _productService.GetProductByName("T-Shirt");

            _shoppingCartService.AddItemToCart(shoppingCart, tennisBall!, 1);
            _shoppingCartService.AddItemToCart(shoppingCart, tennisRacket!, 1);
            _shoppingCartService.AddItemToCart(shoppingCart, tShirt!, 3);

            _discountService.CreateItemDiscount(tShirt!, 3);

            // Act
            var totalPrice = _shoppingCartService.CalculateTotalPrice(shoppingCart);

            // Assert
            Assert.Equal(35, totalPrice);
        }

        [Fact]
        public void CreateDiscountWithMissingProduct_ThrowsException()
        {
            // Arrange
            var nonExistingProduct = new Product("Non-Existing Product", 5);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _discountService.CreateItemDiscount(nonExistingProduct, 3));
        }

        [Fact]
        public void CreateDiscountWithNonPositiveForEvery_ThrowsException()
        {
            // Arrange
            var tShirt = _productService.GetProductByName("T-Shirt");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _discountService.CreateItemDiscount(tShirt!, 0));
        }
    }

}
