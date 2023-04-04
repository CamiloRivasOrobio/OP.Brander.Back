using AutoMapper;
using MediatR;
using OP.Brander.Application.Interfaces;
using OP.Brander.Application.Services;
using OP.Brander.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Brander.Application.Features.CreateFilmCommand.Commands.CreateFilmCommand
{
    public class CreateFilmCommand : IRequest<Response<int>>
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
    public class CreateDataMasterCommandHandler : IRequestHandler<CreateFilmCommand, Response<int>>
    {
        private readonly IFilmService _FilmService;

        public CreateDataMasterCommandHandler(IFilmService FilmService)
        {
            _FilmService = FilmService;
        }

        public async Task<Response<int>> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        {
            return await _FilmService.CreateFilm(request, cancellationToken);
        }
    }
}