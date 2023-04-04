using MediatR;
using OP.Brander.Application.DTOs.Films;
using OP.Brander.Application.Interfaces;
using OP.Brander.Application.Wrappers;

namespace OP.Brander.Application.Features.Film.Queries.GetAllFilmsQuery
{
    public class GetAllFilmsQuery : IRequest<PagedResponse<List<FilmsDto>>>
    {
        public int? Id { get; set; } = null;
        public string? Titulo { get; set; } = null;
        public DateTime? Fecha { get; set; } = null;
        public string? Director { get; set; } = null;
        public string? Argumento { get; set; } = null;
        public float? Duracion { get; set; } = null;
        public int? Genero { get; set; } = null;
        public int? Formato { get; set; } = null;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? Estado { get; set; } = null;
    }
    public class GetAllFilmsQueryHandler : IRequestHandler<GetAllFilmsQuery, PagedResponse<List<FilmsDto>>>
    {
        private readonly IFilmService _FilmService;

        public GetAllFilmsQueryHandler(IFilmService FilmService)
        {
            this._FilmService = FilmService;
        }

        public async Task<PagedResponse<List<FilmsDto>>> Handle(GetAllFilmsQuery request, CancellationToken cancellationToken)
        {
            return await _FilmService.GetAllFilms(request, cancellationToken);
        }
    }
}
