
using XNerd.Ecommerce.Domain.Common;

namespace XNerd.Ecommerce.Domain.Models
{
    public class Image : BaseDomainModel
    {
        public string? Url { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public string? PublicCode { get; set; } //Código público en el servicio de imagenes (Cloudinary)
    }
}