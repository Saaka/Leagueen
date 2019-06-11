using Leagueen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Domain.Configurations
{
    public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.HasKey(x => x.FriendshipId);

            builder
                .Property(x => x.UserId)
                .IsRequired();

            builder
                .Property(x => x.FriendId)
                .IsRequired();

            builder
                .Property(x => x.CreateDate)
                .IsRequired();

            builder
                .Property(x => x.IsActive)
                .IsRequired();

            builder
                .HasIndex(x => x.UserId)
                .ForSqlServerInclude(nameof(Friendship.FriendId), nameof(Friendship.IsActive));
        }
    }
}
