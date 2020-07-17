using Microsoft.EntityFrameworkCore;
using SapoProject.Areas.Admin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SapoProject.Areas.Admin.Models.DTO;

namespace SapoProject.Areas.Admin.Models.Data
{
    public class SapoProjectDbContext :DbContext
    {
        public SapoProjectDbContext(DbContextOptions<SapoProjectDbContext> options): base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<WebInfor> WebInfor { get; set; }
        public DbSet<SapoProject.Areas.Admin.Models.DTO.UserRegister> UserRegister { get; set; }
    }

}
