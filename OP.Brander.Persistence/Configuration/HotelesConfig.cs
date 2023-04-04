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
    public class FormatosConfig : IEntityTypeConfiguration<Formatos>
    {
        public void Configure(EntityTypeBuilder<Formatos> builder)
        {
            builder.ToTable("Formatos");

            builder.HasKey(e => e.Id).HasName("PK__Formatos__3214EC078BF374BA");

            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.Formato)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasColumnType("varchar");

            builder.Property(e => e.Caracteristicas)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasColumnType("varchar");

            builder.Property(e => e.FormatoPelicula)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasColumnType("varchar");
        }
    }
}