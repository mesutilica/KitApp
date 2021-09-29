using KitApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitApp.Data.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.SurName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UserName).HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Phone).HasMaxLength(15);
            builder.Property(x => x.IsActive);
            builder.Property(x => x.CreateDate);
            builder.Property(x => x.RefreshToken);
            builder.Property(x => x.RefreshTokenExpireDate);
            builder.ToTable("AppUsers");
        }
    }
}
