using CoverGo.Task.Application.Discount;
using CoverGo.Task.Domain.Discount.Entities;

namespace CoverGo.Task.Infrastructure.Persistence.InMemory
{
    public class InMemoryDiscountRuleRepository : IDiscountRuleQuery, IDiscountRuleWriteRepository
    {
        private List<DiscountRule> _discountRules;

        public InMemoryDiscountRuleRepository(List<DiscountRule> initialDiscountRules)
        {
            _discountRules = initialDiscountRules ?? new List<DiscountRule>();
        }

        public DiscountRule GetById(int id)
        {
            var discountRule = _discountRules.FirstOrDefault(dr => dr.Id == id);
            if (discountRule == null)
                throw new InvalidOperationException($"Discount rule with id {id} does not exist.");

            return discountRule;
        }

        public List<DiscountRule> GetDiscountRulesAsync()
        {
            return _discountRules.ToList();
        }

        public DiscountRule AddDiscountRuleAsync(DiscountRule discountRule)
        {
            if (discountRule.ProductId <= 0)
                throw new ArgumentException("Product ID must be greater than 0.", nameof(discountRule));

            if (discountRule.DiscountQuantity <= 0)
                throw new ArgumentException("Discount quantity must be greater than 0.", nameof(discountRule));

            if (discountRule.DeductionAmount <= 0)
                throw new ArgumentException("Deduction amount must be greater than 0.", nameof(discountRule));

            if (_discountRules.Any(dr => dr.ProductId == discountRule.ProductId && dr.DiscountQuantity == discountRule.DiscountQuantity))
                throw new InvalidOperationException("Duplicate discount rule cannot be added.");

            discountRule.Id = _discountRules.Any() ? _discountRules.Max(dr => dr.Id) + 1 : 1;
            _discountRules.Add(discountRule);

            return discountRule;
        }

        public SetDiscountRule AddSetDiscountRule(SetDiscountRule setDiscountRule)
        {
            if (setDiscountRule.ProductIds == null || !setDiscountRule.ProductIds.Any() || setDiscountRule.ProductIds.Count() == 1)
                throw new ArgumentException("Product IDs must not be null or empty.", nameof(setDiscountRule));

            _discountRules.Add(setDiscountRule);

            return setDiscountRule;
        }


    }
}
