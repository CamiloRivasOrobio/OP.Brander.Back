using Ardalis.Specification;
using OP.Brander.Domain.Entities;

namespace OP.Brander.Application.Specifications
{
    public class PagedFormatSpecification : Specification<Formatos>
    {
        public PagedFormatSpecification(int? pageSize, int? pageNumber, int? id, string? formato, string? caracteristicas, string? formatoPelicula)
        {
            if (id != null && id > 0)
                Query.Where(x => x.Id == id);

            if (!string.IsNullOrEmpty(formato))
                Query.Where(x => x.Formato == formato);

            if (!string.IsNullOrEmpty(caracteristicas))
                Query.Where(x => x.Caracteristicas == caracteristicas);

            if (!string.IsNullOrEmpty(formatoPelicula))
                Query.Where(x => x.FormatoPelicula == formatoPelicula);

            if (pageSize != null && pageNumber != null)
                Query.Skip(((int)pageNumber - 1) * (int)pageSize)
                    .Take((int)pageSize);
        }
    }
}