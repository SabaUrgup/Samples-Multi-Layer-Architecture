﻿using Device.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.DataAccessLayer.Configuration
{
    /// <summary>
    /// Verilerin veritabanına kaydedilirken yapılacak kısıtlamaları içerir --> Configuration
    /// </summary>
    public class TelConfiguration : IEntityTypeConfiguration<Tel>
    {
        public void Configure(EntityTypeBuilder<Tel> builder)
        {
            //Tablonun primary keyini tanımlar
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Brand).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Color).HasMaxLength(50).IsRequired();
        }
    }
}
