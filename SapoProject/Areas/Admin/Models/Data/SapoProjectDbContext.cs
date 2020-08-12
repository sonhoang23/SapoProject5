using Microsoft.EntityFrameworkCore;
using SapoProject.Areas.Admin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Models.Configurations;
using SapoProject.Areas.Customer.Models.Entities;

namespace SapoProject.Areas.Admin.Models.Data
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
            // modelBuilder.ApplyConfiguration(new ProductColorConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<WebInfor> WebInfor { get; set; }
        //   public DbSet<ProductClient> ProductClient { get; set; }
        public DbSet<Category> Category { get; set; }
        //   public DbSet<ProductClient> ProductClient { get; set; }
       // public DbSet<SapoProject.Areas.Admin.Models.DTO.CategoryEdit> CategoryUpdate { get; set; }
        //   public DbSet<ProductClient> ProductClient { get; set; }
        // public DbSet<CategoryCreate> CategoryCreate { get; set; }
        // public DbSet<ProductColorConfiguration> ProductColorConfiguration { get; set; }
    }

}
