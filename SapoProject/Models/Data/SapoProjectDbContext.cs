using Microsoft.EntityFrameworkCore;
using SapoProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Models.Data
{
    public class SapoProjectDbContext :DbContext
    {
        public SapoProjectDbContext(DbContextOptions<SapoProjectDbContext> options): base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<WebInfor> WebInfor { get; set; }
    }

}
