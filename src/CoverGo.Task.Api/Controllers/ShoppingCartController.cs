using CoverGo.Task.Application;
using CoverGo.Task.Domain;
using CoverGo.Task.Domain.Discount.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoverGo.Task.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartWriteRepository _shoppingCartWriteRepository;
        private readonly IShoppingCartQuery _shoppingCartQuery;

        public ShoppingCartController(IShoppingCartWriteRepository shoppingCartWriteRepository, IShoppingCartQuery shoppingCartQuery)
        {
            _shoppingCartWriteRepository = shoppingCartWriteRepository;
            _shoppingCartQuery = shoppingCartQuery;
        }

        [HttpGet("{id}", Name = "GetShoppingCart")]
        public ActionResult<ShoppingCart> GetById(int id)
        {
            try
            {
                return _shoppingCartQuery.GetCartById(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost(Name = "AddItemToShoppingCart")]
        public ActionResult<ShoppingCart> AddItemToCart(int cartId, Product product)
        {
            try
            {
                var cart = _shoppingCartQuery.GetCartById(cartId);
                _shoppingCartWriteRepository.AddItemToCart(cart, product);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("CalculateTotalPrice/{id}", Name = "CalculateTotalPrice")]
        public ActionResult<decimal> CalculateTotalPrice(int id)
        {
            try
            {
                var cart = _shoppingCartQuery.GetCartById(id);
                var totalPrice = _shoppingCartQuery.CalculateTotalPrice(cart, new DiscountRule());
                return Ok(totalPrice);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
