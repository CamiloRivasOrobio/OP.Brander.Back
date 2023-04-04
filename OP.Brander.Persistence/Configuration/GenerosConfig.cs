using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OP.Brander.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Brander.Persistence.Configuration
{
    public class GenerosConfig : IEntityTypeConfiguration<Generos>
    {
        public void Configure(EntityTypeBuilder<Generos> builder)
        {
            builder.ToTable("Generos");

            builder.HasKey(e => e.Id).HasName("PK__Generos__3214EC078BF374BA");

            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.Genero)
                .HasMaxLength(100)
                .IsRequired(true)
                .HasColumnType("varchar");
        }
    }
}
