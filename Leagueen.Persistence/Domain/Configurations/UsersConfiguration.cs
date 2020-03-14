using Leagueen.Domain.Constants;
using Leagueen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Domain.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);

            builder
                .HasIndex(x => x.UserGuid)
                .ForSqlServerInclude(nameof(User.UserId))
                .HasName("IX_Users_UserGuid")
                .IsUnique();

            builder
                .Property(x => x.UserGuid)
                .IsRequired()
                .HasMaxLength(UserConstants.GuidMaxLength);

            builder
                .Property(x => x.DisplayName)
                .IsRequired()
                .HasMaxLength(UserConstants.MaxDisplayNameLength);

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(UserConstants.MaxEmailLength);

            builder
                .Property(x => x.ImageUrl)
                .IsRequired()
                .HasMaxLength(UserConstants.MaxImageUrlLength);
        }
    }
}
