
using System;
using XNerd.Ecommerce.Domain.Common;

namespace XNerd.Ecommerce.Domain.Models
{
    public class ShoppingCartItem : BaseDomainModel
    {
        public string? Product { get; set; } // Nombre del producto
        public decimal Price { get; set; } // Precio unitario del producto
        public int Quantity { get; set; } // Cantidad del producto en el carrito
        public string? ImageUrl { get; set; } // URL de la imagen del producto
        public string? Category { get; set; } // Nombre de la categoría
        public Guid? ShoppingCartMasterId { get; set; }  
        public int ShoppingCartId { get; set; } // Identificador del carrito de compras
        public virtual ShoppingCart? ShoppingCart { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; } // Cantidad disponible en inventario
    }
}