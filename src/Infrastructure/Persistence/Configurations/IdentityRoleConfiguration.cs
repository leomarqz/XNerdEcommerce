
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace XNerd.Ecommerce.Infrastructure.Persistence.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.Property((role) => role.Id).HasMaxLength(36);
            builder.Property((role)=> role.NormalizedName).HasMaxLength(100);
        }
    }
}