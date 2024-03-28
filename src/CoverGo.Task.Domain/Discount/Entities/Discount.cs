using System.ComponentModel.DataAnnotations;
using CoverGo.Task.Domain;

namespace CoverGo.Task.Domain.Discount.Entities
{
    public class Discount
    {
        public int Id { get; set; }

        public string CouponCode { get; set; } = default!;

        [Required]
        public string Description { get; set; } = default!;

        [Required]
        public bool IsClaimed { get; set; }

        public virtual List<ShoppingCart>? DiscountedCarts { get; set; } = default!;
    }

    public class DiscountRule
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int DiscountQuantity { get; set; }

        public int DeductionAmoun { get; set; }
    }

    public class VoucherResponseModel
    {
        public bool Applied { get; set; }

        public string FailedMessage { get; set; } = default!;

        public decimal DiscountedCartPrice { get; set; }
    }
}
