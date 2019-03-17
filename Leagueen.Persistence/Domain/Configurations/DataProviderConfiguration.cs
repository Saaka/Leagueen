using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Domain.Configurations
{
    public class DataProviderConfiguration : IEntityTypeConfiguration<DataProvider>
    {
        public void Configure(EntityTypeBuilder<DataProvider> builder)
        {
            builder
                .HasKey(x => x.DataProviderId);
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder
                .Property(x => x.Type)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (DataProviderType)v);
            builder
                .HasMany(x => x.Competitions)
                .WithOne(x => x.DataProvider)
                .HasForeignKey(x => x.DataProviderId);
            builder.Metadata
                .FindNavigation(nameof(DataProvider.Competitions))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
