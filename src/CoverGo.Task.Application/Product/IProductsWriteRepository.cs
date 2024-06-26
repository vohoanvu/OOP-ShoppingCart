﻿using CoverGo.Task.Domain;

namespace CoverGo.Task.Application
{
    public interface IProductsWriteRepository
    {
        public ValueTask<Product> GetById(int id, CancellationToken cancellationToken = default);

        public ValueTask<Product> AddProductAsync(Product product, CancellationToken cancellationToken = default);
    }
}
