
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XNerd.Ecommerce.Domain.Models;

namespace XNerd.Ecommerce.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne((product)=> product.Category) // Un producto tiene una categoría
                .WithMany((category)=> category.Products) // Una categoría tiene muchos productos
                .HasForeignKey((product)=> product.CategoryId) // La clave foránea en Product es CategoryId
                .OnDelete(DeleteBehavior.Restrict) // Restricción de eliminación
                .IsRequired(); // La relación es obligatoria

            builder.HasMany((product)=> product.Reviews) // Un producto tiene muchas reseñas
                .WithOne((review)=> review.Product) // Una reseña pertenece a un producto
                .HasForeignKey((review)=> review.ProductId) // La clave foránea en Review es ProductId
                .OnDelete(DeleteBehavior.Cascade); // Eliminación en cascada

            builder.HasMany((product)=> product.Images) // Un producto tiene muchas imágenes
                .WithOne((image)=> image.Product) // Una imagen pertenece a un producto
                .HasForeignKey((image)=> image.ProductId) // La clave foránea en Image es ProductId
                .OnDelete(DeleteBehavior.Cascade); // Eliminación en cascada
        }
    }
}