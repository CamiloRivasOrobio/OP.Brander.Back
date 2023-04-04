using OP.Brander.Application.DTOs.Genders;
using OP.Brander.Application.Features.Gender.Queries.GetAllGendersQuery;
using OP.Brander.Application.Wrappers;

namespace OP.Brander.Application.Interfaces
{
    public interface IGenderService
    {
        Task<PagedResponse<List<GendersDto>>> GetAllGenders(GetAllGendersQuery request, CancellationToken cancellationToken);
    }
}