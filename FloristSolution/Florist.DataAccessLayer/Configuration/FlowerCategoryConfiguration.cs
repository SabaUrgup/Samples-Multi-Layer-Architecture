using Florist.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Florist.DAL.Configuration
{
    public class FlowerCategoryConfiguration : IEntityTypeConfiguration<FlowerCategory>
    {
        public void Configure(EntityTypeBuilder<FlowerCategory> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();

        }
    }
}
