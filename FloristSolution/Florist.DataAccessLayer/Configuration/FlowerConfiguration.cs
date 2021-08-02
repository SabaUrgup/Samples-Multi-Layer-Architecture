using Florist.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Florist.DataAccessLayer.Configuration
{
    public class FlowerConfiguration : IEntityTypeConfiguration<Flower>
    {
        public void Configure(EntityTypeBuilder<Flower> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Price).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Specification).HasMaxLength(100).IsRequired();
            builder.Property(p => p.FlowerCategoryId).IsRequired();

            builder.HasOne(p => p.FlowerCategoryFK)
                .WithMany(p => p.Flowers)
                .HasForeignKey(p => p.FlowerCategoryId);
        }
    }
}
