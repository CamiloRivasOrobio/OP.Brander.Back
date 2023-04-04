using Microsoft.EntityFrameworkCore;
using OP.Brander.Application.Interfaces;
using OP.Brander.Domain.Common;
using OP.Brander.Domain.Entities;
using OP.Brander.Persistence.Configuration;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace OP.Brander.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<Formatos> Formatos { get; set; }
        public DbSet<Peliculas> Peliculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }
    }
}
