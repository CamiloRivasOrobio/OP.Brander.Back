using AutoMapper;
using MediatR;
using OP.Brander.Application.DTOs.Films;
using OP.Brander.Application.Exceptions;
using OP.Brander.Application.Interfaces;
using OP.Brander.Application.Wrappers;

namespace OP.Brander.Application.Features.GetFilmByIdQuery.Queries.GetFilmByIdQuery
{
    public class GetFilmByIdQuery : IRequest<Response<FilmsDto>>
    {
        public int Id { get; set; }
        public class GetFilmByIdQueryHandler : IRequestHandler<GetFilmByIdQuery, Response<FilmsDto>>
        {
            private readonly IFilmService _FilmService;

            public GetFilmByIdQueryHandler(IFilmService FilmService)
            {
                _FilmService = FilmService;
            }

            public async Task<Response<FilmsDto>> Handle(GetFilmByIdQuery request, CancellationToken cancellationToken)
            {
                return await _FilmService.GetFilmById(request, cancellationToken);
            }
        }
    }
}
