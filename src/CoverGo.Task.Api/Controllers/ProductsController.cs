using CoverGo.Task.Application;
using CoverGo.Task.Domain.Product.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoverGo.Task.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsWriteRepository _productsWriteRepository;
        private readonly IProductsQuery _productsQuery;

        public ProductsController(IProductsWriteRepository productsWriteRepository, IProductsQuery productsQuery)
        {
            _productsWriteRepository = productsWriteRepository;
            _productsQuery = productsQuery;
        }

        [HttpGet(Name = "GetProducts")]
        public async ValueTask<ActionResult<List<Product>>> GetAll()
        {
            return await _productsQuery.GetProductsAsync();
        }

        [HttpPost(Name = "CreateProduct")]
        public async ValueTask<ActionResult<Product>> Create(Product product)
        {
            return await _productsWriteRepository.AddProductAsync(product);
        }
    }
}
