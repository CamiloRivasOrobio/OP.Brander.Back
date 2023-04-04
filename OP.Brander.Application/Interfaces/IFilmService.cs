using OP.Brander.Application.DTOs.Films;
using OP.Brander.Application.Features.Film.Queries.GetAllFilmsQuery;
using OP.Brander.Application.Features.DeleteFilmCommand.Commands.DeleteFilmCommand;
using OP.Brander.Application.Features.CreateFilmCommand.Commands.CreateFilmCommand;
using OP.Brander.Application.Wrappers;
using OP.Brander.Application.Features.UpdateFilmCommand.Commands.UpdateFilmCommand;
using OP.Brander.Application.Features.GetFilmByIdQuery.Queries.GetFilmByIdQuery;
using OP.Brander.Application.Features.ChangeStatusFilmCommand.Commands.ChangeStatusFilmCommand;

namespace OP.Brander.Application.Interfaces
{
    public interface IFilmService
    {
        Task<PagedResponse<List<FilmsDto>>> GetAllFilms(GetAllFilmsQuery request, CancellationToken cancellationToken);
        Task<Response<FilmsDto>> GetFilmById(GetFilmByIdQuery request, CancellationToken cancellationToken);
        Task<Response<int>> DeleteFilm(DeleteFilmCommand request, CancellationToken cancellationToken);
        Task<Response<int>> UpdateFilm(UpdateFilmCommand request, CancellationToken cancellationToken);
        Task<Response<int>> CreateFilm(CreateFilmCommand request, CancellationToken cancellationToken);
        Task<Response<int>> ChangeStatusFilm(ChangeStatusFilmCommand request, CancellationToken cancellationToken);
    }
}