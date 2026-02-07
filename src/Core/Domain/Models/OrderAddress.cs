
using XNerd.Ecommerce.Domain.Common;

namespace XNerd.Ecommerce.Domain.Models
{
    public class OrderAddress
    {
        public string? Street { get; set; } // Calle, Avenida, etc.
        public string? City { get; set; }
        public string? State { get; set; } // Departamento, Provincia, Región, etc.
        public string? Country { get; set; }
        public string? ZipCode { get; set; } // Código Postal
        public string? UserName { get; set; }
    }
}