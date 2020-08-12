using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SapoProject.Areas.Admin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.Configurations
{
    public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.ToTable("ProductColor");
         //   builder.HasKey(t => new { t.ProductId, t.ColorId });
         //   builder.HasOne(t => t.Product).WithMany(pc => pc.ProductColors).HasForeignKey(pc => pc.ProductId);
         //   builder.HasOne(t => t.Color).WithMany(pc => pc.ProductColors).HasForeignKey(pc => pc.ColorId);
         //   builder.Property(x => x.Quantity).HasMaxLength(50).IsRequired();
 
        }
    }
}
