using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.Configs
{
    internal class ReaderEntityConfig : IEntityTypeConfiguration<Reader>
    {
        public void Configure(EntityTypeBuilder<Reader> builder)
        {
            builder.ToTable("T_Reader").HasOne(x=>x.ReaderType).;
            builder.HasKey(x => x.Id);
            builder
                .HasOne(x=>x.ReaderType);
            builder.Property(x => x.Name).HasMaxLength(20);
            builder.Property(x=>x.Company).HasMaxLength(50);
            builder.Property(x => x.QQ).HasMaxLength(20);
        }
    }
}
