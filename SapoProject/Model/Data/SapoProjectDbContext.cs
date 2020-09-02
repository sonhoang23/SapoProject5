using Microsoft.EntityFrameworkCore;
using SapoProject.Model.Configurations;
using SapoProject.Model.Entities;

namespace SapoProject.Model.Data
{
    public class SapoProjectDbContext : DbContext
    {
        public SapoProjectDbContext(DbContextOptions<SapoProjectDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {    //confingure using Fluent API
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderClientConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementSlideShowConfiguration());
            // modelBuilder.ApplyConfiguration(new ProductColorConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Client> Client { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<WebInfor> WebInfor { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<OrderClient> OrderClient { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<AdvertisementSlideShow> AdvertisementSlideShows { get; set; }

    }

}
