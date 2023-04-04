using Ardalis.Specification;
using OP.Brander.Domain.Entities;

namespace OP.Brander.Application.Specifications
{
    public class PagedGenderSpecification : Specification<Generos>
    {
        public PagedGenderSpecification(int? pageSize, int? pageNumber, int? id, string? genero)
        {
            if (id != null && id > 0)
                Query.Where(x => x.Id == id);

            if (!string.IsNullOrEmpty(genero))
                Query.Where(x => x.Genero == genero);

            if (pageSize != null && pageNumber != null)
                Query.Skip(((int)pageNumber - 1) * (int)pageSize)
                    .Take((int)pageSize);
        }
    }
}