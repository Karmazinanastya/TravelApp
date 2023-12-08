using Microsoft.EntityFrameworkCore;
using TravelApp.Models;


namespace TravelApp.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Сlient> Clients { get; set; }
        public DbSet<TourPackage> Tours { get; set; }
        public DbSet<Transportation> Transportations { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>(
                entity =>
                {
                    entity.ToTable("hotel");

                    entity.HasKey(k => k.Id);
                });

            modelBuilder.Entity<Сlient>(
                entity =>
                {
                    entity.ToTable("clients");

                    entity.HasKey(k => k.Id);
                });

            modelBuilder.Entity<TourPackage>(
                entity =>
                {
                    entity.ToTable("tour_package");

                    entity.HasKey(k => k.Id);
                });

            modelBuilder.Entity<Transportation>(
                entity =>
                {
                    entity.ToTable("transportation");

                    entity.HasKey(k => k.Id);
                });

            modelBuilder.Entity<Order>(
                entity =>
                {
                    entity.ToTable("order");

                    entity.HasKey(k => k.Id);
                });
        }
    }
}