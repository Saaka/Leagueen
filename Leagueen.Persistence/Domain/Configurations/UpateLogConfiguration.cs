using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Domain.Configurations
{
    public class UpateLogConfiguration : IEntityTypeConfiguration<UpdateLog>
    {
        public void Configure(EntityTypeBuilder<UpdateLog> builder)
        {
            builder
                .HasKey(x => x.UpdateLogId);
            builder
                .Property(x => x.Date)
                .IsRequired();
            builder
                .Property(x => x.LogType)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (UpdateLogType)v);
        }
    }
}
