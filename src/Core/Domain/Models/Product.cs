
using System.Collections;
using System.Collections.Generic;
using XNerd.Ecommerce.Domain.Common;
using XNerd.Ecommerce.Domain.Enums;

namespace XNerd.Ecommerce.Domain.Models
{
    public class Product : BaseDomainModel
    {
        public string? Name { get; set; }
        public decimal Price { get; set; } // Precio con dos decimales
        public string? Description { get; set; }
        public int Rating { get; set; }
        public string? Seller { get; set; } // Vendedor
        public int Stock { get; set; } // Cantidad disponible
        public ProductStatus Status { get; set; } = ProductStatus.Active;
        public int CategoryId { get; set; } // Foreign key
        public Category? Category { get; set; }

        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<Image>? Images { get; set; }

    }
}