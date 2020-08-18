using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SapoProject.Areas.Admin.Models.Entities;
using SapoProject.Model.Entities;

namespace SapoProject.Areas.Admin.Models.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ProductName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Price).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.OriginalPrice).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.ShortDescription).IsRequired();
            builder.Property(x => x.EntireDescription).IsRequired();
            builder.Property(x => x.FilePath).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();
            builder.HasOne<Category>(s => s.Category).WithMany(g => g.Products).HasForeignKey(s => s.CategoryId);
            builder.HasOne<OrderDetail>(s => s.OrderDetail).WithOne(ad => ad.Product).HasForeignKey<OrderDetail>(ad => ad.ProductId);
        }
    }
}
