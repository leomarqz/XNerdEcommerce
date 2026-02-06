
using XNerd.Ecommerce.Domain.Common;

namespace XNerd.Ecommerce.Domain.Models
{
    public class Review : BaseDomainModel
    {
        public string? Name { get; set; } // Nombre del que crea la reseña
        public int Rating { get; set; } // Calificación
        public string? Comment { get; set; } // Comentario
        public int ProductId { get; set; } // Foreign key
    }
}
