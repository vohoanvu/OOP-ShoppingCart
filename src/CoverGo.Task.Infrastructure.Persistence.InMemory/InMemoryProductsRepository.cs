using System.Collections.Immutable;
using CoverGo.Task.Application;
using CoverGo.Task.Domain.Product.Entities;

namespace CoverGo.Task.Infrastructure.Persistence.InMemory;

public class InMemoryProductsRepository : IProductsQuery, IProductsWriteRepository
{
    private ImmutableList<Product> _products = ImmutableList<Product>.Empty;

    public ValueTask<Product> GetById(int id, CancellationToken cancellationToken = default)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            throw new InvalidOperationException($"Product with id {id} does not exist.");
        return ValueTask.FromResult(product);
    }

    public ValueTask<List<Product>> ExecuteAsync()
    {
        return ValueTask.FromResult(_products.ToList());
    }

    public ValueTask AddProduct(Product product, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("Product name is required.", nameof(product));

        if (product.Price <= 0)
            throw new ArgumentException("Product price must be greater than 0.", nameof(product));

        if (_products.Any(p => p.Name == product.Name && p.Price == product.Price))
            throw new InvalidOperationException("Duplicate product cannot be added.");

        product.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
        _products = _products.Add(product);

        return ValueTask.CompletedTask;
    }
}