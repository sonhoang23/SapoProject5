using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SapoProject.Areas.Admin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(x => x.ProductName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Price).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.OriginalPrice).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.ShortDescription).IsRequired();
            builder.Property(x => x.EntireDescription).IsRequired();
            builder.Property(x => x.Status).IsRequired();


        }
    }
}
