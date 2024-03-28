namespace CoverGo.Task.Api.Tests
{
    public class UserStory3Tests
    {
        private ProductService _productService;
        private ShoppingCartService _shoppingCartService;

        public UserStory3Tests()
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
        public void CalculateTotalPriceOfShoppingCart_ReturnsCorrectTotalPrice()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var tennisBall = _productService.GetProductByName("Tennis Ball");
            var tennisRacket = _productService.GetProductByName("Tennis Racket");
            var tShirt = _productService.GetProductByName("T-Shirt");

            _shoppingCartService.AddItemToCart(shoppingCart, tennisBall!, 1);
            _shoppingCartService.AddItemToCart(shoppingCart, tennisRacket!, 2);
            _shoppingCartService.AddItemToCart(shoppingCart, tShirt!, 1);

            // Act
            var totalPrice = _shoppingCartService.CalculateTotalPrice(shoppingCart);

            // Assert
            Assert.Equal(75, totalPrice);
        }
    }

}
