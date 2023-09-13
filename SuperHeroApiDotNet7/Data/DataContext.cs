global using Microsoft.EntityFrameworkCore;
using SuperHeroApiDotNet7.Entity.User;

namespace SuperHeroApiDotNet7.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=LAPTOP-E1C7KIVV\\DATNGUYEN;Database=Superherodb;Trusted_Connection=true;TrustServerCertificate=true;");
            optionsBuilder.UseSqlServer("Server=DESKTOP-E2OD2LD\\SQLEXPRESS01;Database=Superherodb;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<UserEntity> User { get; set; }
    }
}
