using AutoMapper;
using MediatR;
using OP.Brander.Application.Exceptions;
using OP.Brander.Application.Interfaces;
using OP.Brander.Application.Wrappers;
using OP.Brander.Domain.Entities;

namespace OP.Brander.Application.Features.UpdateFilmCommand.Commands.UpdateFilmCommand
{
    public class UpdateFilmCommand : IRequest<Response<int>>
    {
        public int? Id { get; set; } = null;
        public string? Titulo { get; set; } = null;
        public DateTime? Fecha { get; set; } = null;
        public string? Director { get; set; } = null;
        public string? Argumento { get; set; } = null;
        public float? Duracion { get; set; } = null;
        public int? Genero { get; set; } = null;
        public int? Formato { get; set; } = null;
        public int? Estado { get; set; } = null;
    }
    public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommand, Response<int>>
    {
        private readonly IFilmService _FilmService;

        public UpdateFilmCommandHandler(IFilmService FilmService)
        {
            _FilmService = FilmService;
        }

        public async Task<Response<int>> Handle(UpdateFilmCommand request, CancellationToken cancellationToken)
        {
            return await _FilmService.UpdateFilm(request, cancellationToken);
        }
    }
}
