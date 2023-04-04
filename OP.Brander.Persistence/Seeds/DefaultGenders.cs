using Microsoft.EntityFrameworkCore;
using OP.Brander.Domain.Entities;

namespace OP.Brander.Persistence.Seeds
{
    public static class DefaultGenders
    {
        public static void Seeds(ModelBuilder builder)
        {
            builder.Entity<Generos>().HasData(new List<Generos>()
            {
                new Generos
                {
                    Id = 1,
                    Genero = "Acción",
                },
                new Generos {
                    Id = 2,
                    Genero = "Aventuras",
                },
                new Generos {
                    Id = 3,
                    Genero = "Ciencia Ficción",
                },
                new Generos {
                    Id = 4,
                    Genero = "Ciencia Ficción",
                },
                new Generos
                {
                    Id = 5,
                    Genero = "No-Ficción/Documental",
                },
                new Generos {
                    Id = 6,
                    Genero = "Drama",
                },
                new Generos {
                    Id = 7,
                    Genero = "Fantasía",
                },
                new Generos {
                    Id = 8,
                    Genero = "Musical",
                }
            });
        }
    }
}
