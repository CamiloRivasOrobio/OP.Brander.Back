using MediatR;
using OP.Brander.Application.DTOs.Genders;
using OP.Brander.Application.Interfaces;
using OP.Brander.Application.Wrappers;

namespace OP.Brander.Application.Features.Gender.Queries.GetAllGendersQuery
{
    public class GetAllGendersQuery : IRequest<PagedResponse<List<GendersDto>>>
    {
        public int? Id { get; set; } = null;
        public string? Genero { get; set; } = null;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllGendersQueryHandler : IRequestHandler<GetAllGendersQuery, PagedResponse<List<GendersDto>>>
    {
        private readonly IGenderService _Genderservice;

        public GetAllGendersQueryHandler(IGenderService Genderservice)
        {
            this._Genderservice = Genderservice;
        }

        public async Task<PagedResponse<List<GendersDto>>> Handle(GetAllGendersQuery request, CancellationToken cancellationToken)
        {
            return await _Genderservice.GetAllGenders(request, cancellationToken);
        }
    }
}
