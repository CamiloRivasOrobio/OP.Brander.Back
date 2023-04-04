using Microsoft.EntityFrameworkCore;
using OP.Brander.Domain.Entities;

namespace OP.Brander.Persistence.Seeds
{
    public static class DefaultFormats
    {
        public static void Seeds(ModelBuilder builder)
        {
            builder.Entity<Formatos>().HasData(new List<Formatos>()
            {
                new Formatos
                {
                    Id = 1,
                    Formato = "Cinerama",
                    Caracteristicas = "Formato panorámico abandonado el 1963.",
                    FormatoPelicula = "35mm"
                },
                new Formatos
                {
                    Id = 2,
                    Formato = "Cinemascope",
                    Caracteristicas = "Formato panorámico introducido el 1953.",
                    FormatoPelicula = "35mm"
                },
                new Formatos
                {
                    Id = 3,
                    Formato = "Vistavision",
                    Caracteristicas = "Formato panorámico creado por Paramount Pictures.",
                    FormatoPelicula = ""
                },
                new Formatos
                {
                    Id = 4,
                    Formato = "IMAX",
                    Caracteristicas = "Formato panorámico de resolución y definición muy elevada.",
                    FormatoPelicula = "70mm"
                },
            });
        }
    }
}
