
using System.Collections.Generic;
using XNerd.Ecommerce.Domain.Common;

namespace XNerd.Ecommerce.Domain.Models
{
    public class Category : BaseDomainModel
    {
        public string? Name { get; set; } //100 characters

        public virtual ICollection<Product>? Products { get; set; }

    }
}