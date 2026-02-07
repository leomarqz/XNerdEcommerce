
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XNerd.Ecommerce.Domain.Models;

namespace Infrastructure.Persistence.Configurations
{
    public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property((category)=> category.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}