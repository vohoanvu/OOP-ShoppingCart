using CoverGo.Task.Domain.Discount.Entities;

namespace CoverGo.Task.Application.Discount
{
    public interface IDiscountRuleQuery
    {
        DiscountRule GetById(int id);

        List<DiscountRule>  GetDiscountRulesAsync();
    }

    public interface IDiscountRuleWriteRepository
    {
        DiscountRule AddDiscountRuleAsync(DiscountRule discountRule);
    }

}
