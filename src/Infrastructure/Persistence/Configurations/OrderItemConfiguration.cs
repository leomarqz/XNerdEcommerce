
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using XNerd.Ecommerce.Domain.Models;

namespace XNerd.Ecommerce.Infrastructure.Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property((item)=> item.Price).HasColumnType("decimal(18,2)");
        }
    }
}