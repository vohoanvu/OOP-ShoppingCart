namespace CoverGo.Task.Api.Tests
{
    // Define a skeleton for the Product class
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    // Define a skeleton for the ProductService class
    public class ProductService
    {
        private List<Product> _products = new List<Product>();

        public void AddProduct(Product product)
        {
            // Placeholder for the actual add product logic
        }

        public IEnumerable<Product> GetAvailableProducts()
        {
            // Placeholder for the actual get products logic
            return _products;
        }

        public Product? GetProductByName(string name)
        {
            // Placeholder for the actual get product by name logic
            return _products.FirstOrDefault(p => p.Name == name);
        }
    }

    public class ShoppingCart
    {
        public List<Product>? Items { get; set; }
        public int Quantity { get; set; }
    }

    public class ShoppingCartService
    {
        public void AddItemToCart(ShoppingCart shoppingCart, Product product, int quantity)
        {
            throw new NotImplementedException();
        }

        public int CalculateTotalPrice(ShoppingCart shoppingCart)
        {
            throw new NotImplementedException();
        }
    }

    public class DiscountService
    {
        public void CreateItemDiscount(Product product, int discountQuantity)
        {
            throw new NotImplementedException();
        }

        public bool IsDiscountApplied(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
