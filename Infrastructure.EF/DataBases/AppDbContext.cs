using Entities;
using Infrastructure.EF.EntityConfigs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.DataBases
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HW16;Integrated Security=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Reporter>().Property(x => x.FirstName).HasMaxLength(50); //also can configure here

            modelBuilder.ApplyConfiguration(new NewsEntityConfig());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfigs());
            modelBuilder.ApplyConfiguration(new ReporterEntityConfig());
            modelBuilder.ApplyConfiguration(new AdminEntityConfig());
        }
        public DbSet<News> News { get; set; }
        public DbSet<Reporter> Reporters { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
