using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OP.Brander.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OP.Brander.Persistence.Configuration
{
    public class PeliculasConfig : IEntityTypeConfiguration<Peliculas>
    {
        public void Configure(EntityTypeBuilder<Peliculas> builder)
        {
            builder.ToTable("Peliculas");

            builder.HasKey(e => e.Id).HasName("PK__Peliculas__3214EC078BF374BA");

            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.Titulo)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasColumnType("varchar");

            builder.Property(e => e.Fecha)
                .IsRequired(true)
                .HasColumnType("datetime");

            builder.Property(e => e.Director)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasColumnType("varchar");

            builder.Property(e => e.Argumento)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasColumnType("varchar");

            builder.Property(e => e.Duracion)
                .IsRequired(true)
                .HasColumnType("float");

            builder.Property(e => e.Genero)
                .IsRequired(true)
                .HasColumnType("int");

            builder.Property(e => e.Formato)
                .IsRequired(true)
                .HasColumnType("int");

            builder.HasOne(d => d.FormatoNavigation).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.Formato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Formato");

            builder.HasOne(d => d.GeneroNavigation).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.Genero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pelicula_Genero");
        }
    }
}
