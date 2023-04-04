using AutoMapper;
using MediatR;
using OP.Brander.Application.Exceptions;
using OP.Brander.Application.Interfaces;
using OP.Brander.Application.Wrappers;
using OP.Brander.Domain.Entities;

namespace OP.Brander.Application.Features.ChangeStatusFilmCommand.Commands.ChangeStatusFilmCommand
{
    public class ChangeStatusFilmCommand : IRequest<Response<int>>
    {
        public int? Id { get; set; } = null;
    }
    public class ChangeStatusFilmCommandHandler : IRequestHandler<ChangeStatusFilmCommand, Response<int>>
    {
        private readonly IFilmService _FilmService;

        public ChangeStatusFilmCommandHandler(IFilmService FilmService)
        {
            _FilmService = FilmService;
        }

        public async Task<Response<int>> Handle(ChangeStatusFilmCommand request, CancellationToken cancellationToken)
        {
            return await _FilmService.ChangeStatusFilm(request, cancellationToken);
        }
    }
}
