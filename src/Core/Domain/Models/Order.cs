
using System.Collections.Generic;

using XNerd.Ecommerce.Domain.Common;
using XNerd.Ecommerce.Domain.Enums;

namespace XNerd.Ecommerce.Domain.Models
{
    public class Order : BaseDomainModel
    {
        public Order(){}

        public Order(
            string? buyerName, string? buyerUsername, OrderAddress? shippingAddress, 
            decimal subTotal, decimal tax, decimal shippingCost,  
            decimal total
        )
        {
            BuyerName = buyerName;
            BuyerUsername = buyerUsername;
            ShippingAddress = shippingAddress;
            SubTotal = subTotal;
            Tax = tax;
            ShippingCost = shippingCost;
            Total = total;
        }

        public string? BuyerName { get; set; }
        public string? BuyerUsername { get; set; }
        public OrderAddress? ShippingAddress { get; set; }
        public IReadOnlyList<OrderItem>? Items { get; set; }
        public decimal SubTotal { get; set; } // Total before taxes and discounts
        public decimal Tax { get; set; } // Applied taxes
        public decimal ShippingCost { get; set; } 
        public OrderStatus Status { get; set; } = OrderStatus.Pending; // Order status
        public decimal Total { get; set; } // Final total amount

        public string? PaymentIntentId { get; set; } // Stripe Payment Intent ID
        public string? ClientSecret { get; set; } // Stripe Client Secret for frontend payment processing
        public string? StripeApiKey { get; set; } // Stripe API Key
    
    }
}