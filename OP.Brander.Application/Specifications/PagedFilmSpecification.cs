using Ardalis.Specification;
using OP.Brander.Domain.Entities;

namespace OP.Brander.Application.Specifications
{
    public class PagedFilmSpecification : Specification<Peliculas>
    {
        public PagedFilmSpecification(int? pageSize, int? pageNumber, int? id, string? titulo, string? director, string? argumento,
            float? duracion, int? genero, int? formato)
        {
            if (id != null && id > 0)
                Query.Where(x => x.Id == id);

            if (!string.IsNullOrEmpty(titulo))
                Query.Where(x => x.Titulo == titulo);

            if (!string.IsNullOrEmpty(director))
                Query.Where(x => x.Director == director);

            if (!string.IsNullOrEmpty(argumento))
                Query.Where(x => x.Argumento == argumento);

            if (duracion != null && duracion > 0)
                Query.Where(x => x.Duracion == duracion);

            if (genero != null && genero > 0)
                Query.Where(x => x.Genero == genero);

            if (formato != null && formato > 0)
                Query.Where(x => x.Formato == formato);

            if (pageSize != null && pageNumber != null)
                Query.Skip(((int)pageNumber - 1) * (int)pageSize)
                    .Take((int)pageSize);
        }
    }
}