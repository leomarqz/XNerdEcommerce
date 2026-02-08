
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XNerd.Ecommerce.Domain.Enums;
using XNerd.Ecommerce.Domain.Models;

namespace XNerd.Ecommerce.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(
                (order)=> order.ShippingAddress, // Order has one ShippingAddress
                (x)=>{ x.WithOwner(); } // ShippingAddress is owned by Order, so it doesn't have its own table
            );

            builder.HasMany((order)=> order.Items ) // Order has many items
                .WithOne((item)=> item.Order) // Each item has one order
                .HasForeignKey((item)=> item.OrderId) // The foreign key in OrderItem is OrderId
                .OnDelete(DeleteBehavior.Cascade); // When an order is deleted, its items are also deleted

            builder.Property((order)=> order.Status)
                .HasConversion(
                    (status) => status.ToString(), // Convert enum to string for storage
                    (str) => (OrderStatus) Enum.Parse(typeof(OrderStatus), str) // Convert string back to enum
                ); // Store the enum as a string in the database

            // another way to store enum as string
            // builder.Property((order)=> order.Status).HasConversion<string>();
            
        }
    }
}