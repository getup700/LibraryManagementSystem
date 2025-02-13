using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.Configs
{
    internal class BookEntityConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("T_Books");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ISBN).HasMaxLength(25);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Author).HasMaxLength(50);
            builder.Property(x => x.Publisher).HasMaxLength(50);
            builder.Property(x => x.Price).HasPrecision(18, 2);
        }
    }
}
