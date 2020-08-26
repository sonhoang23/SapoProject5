using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SapoProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Model.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            {
                builder.ToTable("OrderDetail");
                builder.HasKey(x => x.OrderDetailId);
                builder.Property(x => x.OrderDetailId).UseIdentityColumn();
                builder.Property(x => x.Quantity).HasMaxLength(50).IsRequired();
                builder.Property(x => x.DateCreated).HasColumnType("DateTime").IsRequired();
                builder.Property(x => x.Status).IsRequired();
                builder.HasOne<OrderClient>(s => s.OrderClient).WithMany(g => g.OrderDetails).HasForeignKey(s => s.OrderClientId);
                
            }
        }

        
    }
}
