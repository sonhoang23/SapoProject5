using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SapoProject.Areas.Admin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            {
                builder.ToTable("Category");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).UseIdentityColumn();
                builder.Property(x => x.CategoryName).HasMaxLength(50).IsRequired();
                builder.Property(x => x.IsShowOnHome).HasMaxLength(50).IsRequired();
                builder.Property(x => x.ParentId).HasMaxLength(50).IsRequired();
                builder.Property(x => x.ShortDescription).HasMaxLength(50).IsRequired();
                builder.Property(x => x.SortOrder).IsRequired();
                builder.Property(x => x.imageURL).IsRequired();
                builder.Property(x => x.Status).IsRequired();
            }
        }

    }
}
