using CoverGo.Task.Domain.Product.Entities;

namespace CoverGo.Task.Application
{
    public interface IProductsQuery
    {
        public ValueTask<List<Product>> ExecuteAsync();
    }
}
