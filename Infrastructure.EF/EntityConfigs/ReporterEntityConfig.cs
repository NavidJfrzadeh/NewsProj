using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.EntityConfigs
{
    public class ReporterEntityConfig : IEntityTypeConfiguration<Reporter>
    {
        public void Configure(EntityTypeBuilder<Reporter> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Password).HasMaxLength(200);
        }
    }
}