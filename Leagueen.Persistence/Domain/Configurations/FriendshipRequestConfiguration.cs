using Leagueen.Domain.Constants;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Domain.Configurations
{
    public class FriendshipRequestConfiguration : IEntityTypeConfiguration<FriendshipRequest>
    {
        public void Configure(EntityTypeBuilder<FriendshipRequest> builder)
        {
            builder.HasKey(x => x.FriendshipRequestId);
            
            builder
                .HasIndex(x => x.FriendshipRequestGuid)
                .HasName("IX_FriendshipRequestGuid")
                .IsUnique();

            builder
                .Property(x => x.FriendshipRequestGuid)
                .IsRequired()
                .HasMaxLength(CommonConstants.GuidMaxLength);

            builder
                .Property(x => x.RequesterId)
                .IsRequired();

            builder
                .Property(x => x.AddresseeId)
                .IsRequired();

            builder
                .Property(x => x.CreateDate)
                .IsRequired();

            builder
                .Property(x => x.Status)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (FriendshipRequestStatus)v);
        }
    }
}
