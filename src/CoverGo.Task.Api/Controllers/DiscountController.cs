using CoverGo.Task.Application.Discount;
using CoverGo.Task.Domain.Discount.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoverGo.Task.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRuleWriteRepository _discountRuleWriteRepository;
        private readonly IDiscountRuleQuery _discountRuleQuery;

        public DiscountController(IDiscountRuleWriteRepository discountRuleWriteRepository, IDiscountRuleQuery discountRuleQuery)
        {
            _discountRuleWriteRepository = discountRuleWriteRepository;
            _discountRuleQuery = discountRuleQuery;
        }

        [HttpGet(Name = "GetDiscountRules")]
        public ActionResult<List<DiscountRule>> GetAll()
        {
            return _discountRuleQuery.GetDiscountRulesAsync();
        }

        [HttpPost(Name = "CreateDiscountRule")]
        public ActionResult<DiscountRule> Create(DiscountRule discountRule)
        {
            try
            {
                return _discountRuleWriteRepository.AddDiscountRuleAsync(discountRule);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
