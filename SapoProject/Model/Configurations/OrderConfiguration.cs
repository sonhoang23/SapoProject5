using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SapoProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Model.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            {
                builder.ToTable("Order");
                builder.HasKey(x => x.OrderId);
                builder.Property(x => x.OrderId).UseIdentityColumn();
                builder.Property(x => x.Status).HasMaxLength(50).IsRequired();
                builder.Property(x => x.DateCreated).IsRequired();
                builder.Property(x => x.DateCompleted).IsRequired();
                builder.HasOne<Client>(s => s.Client).WithMany(g => g.Order).HasForeignKey(s => s.ClientId);

            }
        }

        
    }
}
