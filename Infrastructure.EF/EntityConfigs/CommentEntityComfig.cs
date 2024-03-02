using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.EntityConfigs
{
    public class CommentEntityComfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Description).HasMaxLength(300);
            builder.HasOne(x => x.Reporter)
                .WithMany(y => y.Comments)
                .HasForeignKey(x => x.ReporterId);
        }
    }
}