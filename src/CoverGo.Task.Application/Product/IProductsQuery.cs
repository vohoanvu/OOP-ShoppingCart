using CoverGo.Task.Domain;

namespace CoverGo.Task.Application
{
    public interface IProductsQuery
    {
        public ValueTask<List<Product>> GetProductsAsync();
    }
}
