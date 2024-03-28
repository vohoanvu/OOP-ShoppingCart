namespace CoverGo.Task.Domain
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public string CartLabel { get; set; } = "Default Cart Label";

        public required List<Product> Items { get; set; }
    }
}
