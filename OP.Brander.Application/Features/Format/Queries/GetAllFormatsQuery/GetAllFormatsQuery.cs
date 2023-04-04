using MediatR;
using OP.Brander.Application.DTOs.Formats;
using OP.Brander.Application.Interfaces;
using OP.Brander.Application.Wrappers;

namespace OP.Brander.Application.Features.Format.Queries.GetAllFormatsQuery
{
    public class GetAllFormatsQuery : IRequest<PagedResponse<List<FormatsDto>>>
    {
        public int? Id { get; set; } = null;
        public string? Formato { get; set; } = null;
        public string? Caracteristicas { get; set; } = null;
        public string? FormatoPelicula { get; set; } = null;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllFormatsQueryHandler : IRequestHandler<GetAllFormatsQuery, PagedResponse<List<FormatsDto>>>
    {
        private readonly IFormatService _Formatservice;

        public GetAllFormatsQueryHandler(IFormatService Formatservice)
        {
            this._Formatservice = Formatservice;
        }

        public async Task<PagedResponse<List<FormatsDto>>> Handle(GetAllFormatsQuery request, CancellationToken cancellationToken)
        {
            return await _Formatservice.GetAllFormats(request, cancellationToken);
        }
    }
}
