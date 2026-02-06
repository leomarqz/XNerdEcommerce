

using XNerd.Ecommerce.Domain.Common;

namespace XNerd.Ecommerce.Domain.Models
{
    public class Country : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Iso2 { get; set; }
        public string? Iso3 { get; set; }
    }
}