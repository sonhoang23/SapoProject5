using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SapoProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Model.Configurations
{
    public class AdvertisementSlideShowConfiguration : IEntityTypeConfiguration<AdvertisementSlideShow>
    {
        public void Configure(EntityTypeBuilder<AdvertisementSlideShow> builder)
        {
            builder.ToTable("AdvertisementSlideShow");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.AdvertisementName).IsRequired();
            builder.Property(x => x.AdvertisementLongDescription).IsRequired();
            builder.Property(x => x.AdvertisementShortDescription).IsRequired();
            builder.Property(x => x.AdvertisementImageUrl).IsRequired();
            builder.Property(x => x.AdvertisementDestination).IsRequired();
            builder.Property(x => x.DateCreated).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.CompletedDate).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.Status).IsRequired();

        }
    }
}
