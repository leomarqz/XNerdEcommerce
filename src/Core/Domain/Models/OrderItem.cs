
using XNerd.Ecommerce.Domain.Common;

namespace XNerd.Ecommerce.Domain.Models
{
    public class OrderItem : BaseDomainModel
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public string? ProductName { get; set; }        
        public string? ImageUrl { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }
        
        public int ProductItemId { get; set; }

    }
}