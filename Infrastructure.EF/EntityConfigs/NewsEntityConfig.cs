using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.EntityConfigs
{
    public class NewsEntityConfig : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.ShortDescription).HasMaxLength(500);
            builder.Property(x => x.Description).HasMaxLength(4000);
            builder.Property(x => x.PictureAlt).HasMaxLength(100);
            builder.Property(x => x.PictureLocation).HasMaxLength(2000);
            builder.HasOne<Reporter>(x => x.Reporter)
                .WithMany(y => y.News)
                .HasForeignKey(x => x.ReporterId);
            builder.HasOne<Category>(x => x.Category)
                .WithMany(y => y.News)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
