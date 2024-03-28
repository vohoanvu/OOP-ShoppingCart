using CoverGo.Task.Domain.Product.Entities;

namespace CoverGo.Task.Application
{
    public interface IProductsWriteRepository
    {
        public ValueTask<Product> GetById(int id, CancellationToken cancellationToken = default);

        public ValueTask AddProduct(Product product, CancellationToken cancellationToken = default);
    }
}
