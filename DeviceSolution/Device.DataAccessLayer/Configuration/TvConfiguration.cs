using Device.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.DataAccessLayer.Configuration
{    /// <summary>
     /// Verilerin veritabanına kaydedilirken yapılacak kısıtlamaları içerir --> Configuration
     /// </summary>
    public class TvConfiguration : IEntityTypeConfiguration<Tv>
    {
        public void Configure(EntityTypeBuilder<Tv> builder)
        {
            //Tablonun primary keyini tanımlar
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Brand).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Size).IsRequired();

        }
    }
    
}
