
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using XNerd.Ecommerce.Domain.Models;

namespace XNerd.Infrastructure.Persistence.Configurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasMany((cart)=> cart.ShoppingCartItems) // Un carrito tiene muchos ítems
                .WithOne((item) => item.ShoppingCart) // Cada ítem pertenece a un carrito
                .HasForeignKey((item) => item.ShoppingCartId) // La clave foránea en ShoppingCartItem
                .OnDelete(DeleteBehavior.Cascade) // Si se elimina un carrito, se eliminan sus ítems asociados
                .IsRequired(); 
                
        }
    }
}