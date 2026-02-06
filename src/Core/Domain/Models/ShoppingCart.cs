
using System;
using System.Collections.Generic;
using XNerd.Ecommerce.Domain.Common;

namespace XNerd.Ecommerce.Domain.Models
{
    public class ShoppingCart : BaseDomainModel
    {
        public Guid? ShoppingCartMasterId { get; set; }
        public virtual ICollection<ShoppingCartItem>? ShoppingCartItems { get; set; }
    }
}