using System.ComponentModel.DataAnnotations;
using CoverGo.Task.Domain.Product.Entities;

namespace CoverGo.Task.Domain.ShopppingCart.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public string CartLabel { get; set; } = "Default Cart Label";

        [Required]
        public bool IsDiscounted { get; set; }

        // Navigation Properties
        public int? VoucherId { get; set; }
        public virtual CoverGo.Task.Domain.Discount.Entities.Discount? VoucherCode { get; set; } //assuming each Cart can only claim one Voucher at a time

        public virtual required List<ProductInShoppingCart> ProductCarts { get; set; }
    }
}
