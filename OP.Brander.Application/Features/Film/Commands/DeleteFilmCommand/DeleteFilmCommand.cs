using AutoMapper;
using MediatR;
using OP.Brander.Application.Exceptions;
using OP.Brander.Application.Interfaces;
using OP.Brander.Application.Wrappers;
using OP.Brander.Domain.Entities;

namespace OP.Brander.Application.Features.DeleteFilmCommand.Commands.DeleteFilmCommand
{
    public class DeleteFilmCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommand, Response<int>>
    {
        private readonly IFilmService _FilmService;

        public DeleteFilmCommandHandler(IFilmService FilmService)
        {
            _FilmService = FilmService;
        }

        public async Task<Response<int>> Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
        {
            return await _FilmService.DeleteFilm(request, cancellationToken);
        }
    }
}
