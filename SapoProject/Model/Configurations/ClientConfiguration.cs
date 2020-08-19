using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SapoProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Model.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CustomerName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Age).HasMaxLength(3).IsRequired();
            builder.Property(x => x.Sex).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.EmailReset).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ClientAccount).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ClientPassWord).HasMaxLength(50).IsRequired();
        }

      
    }
}