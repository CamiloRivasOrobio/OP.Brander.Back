using AutoMapper;
using OP.Brander.Application.DTOs.Films;
using OP.Brander.Application.Exceptions;
using OP.Brander.Application.Features.Film.Queries.GetAllFilmsQuery;
using OP.Brander.Application.Features.DeleteFilmCommand.Commands.DeleteFilmCommand;
using OP.Brander.Application.Features.CreateFilmCommand.Commands.CreateFilmCommand;
using OP.Brander.Application.Interfaces;
using OP.Brander.Application.Specifications;
using OP.Brander.Application.Wrappers;
using OP.Brander.Domain.Entities;
using OP.Brander.Application.Features.UpdateFilmCommand.Commands.UpdateFilmCommand;
using OP.Brander.Application.Features.GetFilmByIdQuery.Queries.GetFilmByIdQuery;
using NPOI.POIFS.Crypt.Dsig;
using OP.Brander.Application.Features.ChangeStatusFilmCommand.Commands.ChangeStatusFilmCommand;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;
using System.IO;

namespace OP.Brander.Application.Services
{
    public class FilmService : IFilmService
    {
        private readonly IRepositoryAsync<Peliculas> _repositoryAsync;
        private readonly IRepositoryAsync<Generos> _repositoryGeneroAsync;
        private readonly IRepositoryAsync<Formatos> _repositoryFormatoAsync;
        private readonly IMapper _mapper;

        public FilmService(IRepositoryAsync<Peliculas> repositoryAsync, IRepositoryAsync<Generos> repositoryGeneroAsync, IRepositoryAsync<Formatos> repositoryFormatoAsync)
        {
            _repositoryAsync = repositoryAsync;
            _repositoryGeneroAsync = repositoryGeneroAsync;
            _repositoryFormatoAsync = repositoryFormatoAsync;
        }

        public async Task<PagedResponse<List<FilmsDto>>> GetAllFilms(GetAllFilmsQuery request, CancellationToken cancellationToken)
        {
            var Films = await _repositoryAsync.ListAsync(new PagedFilmSpecification(request.PageSize, request.PageNumber, request.Id, request.Titulo, request.Director, request.Argumento,
                request.Duracion, request.Genero, request.Formato));
            var FilmsCount = await _repositoryAsync.CountAsync(new PagedFilmSpecification(request.PageSize, request.PageNumber, request.Id, request.Titulo, request.Director, request.Argumento,
                request.Duracion, request.Genero, request.Formato));
            var FilmsDto = new List<FilmsDto>();
            if (Films.Count > 0)
            {
                FilmsDto = (from data in Films
                            select new FilmsDto
                            {
                                Id = data.Id,
                                Titulo = data.Titulo,
                                Director = data.Director,
                                Argumento = data.Argumento,
                                Duracion = data.Duracion,
                                Genero = data.Genero,
                                Estado = data.Estado,
                                Formato = data.Formato,
                                Fecha = data.Fecha,
                                GeneroNavigation = _repositoryGeneroAsync.GetByIdAsync(data.Genero).Result,
                                FormatoNavigation = _repositoryFormatoAsync.GetByIdAsync(data.Formato).Result
                            }).ToList();
            }
            return new PagedResponse<List<FilmsDto>>(FilmsDto, request.PageNumber, request.PageSize, FilmsCount);
        }

        public async Task<Response<int>> CreateFilm(CreateFilmCommand request, CancellationToken cancellationToken)
        {
            var newRegister = new Peliculas()
            {
                Id = 0,
                Titulo = request.Titulo,
                Director = request.Director,
                Argumento = request.Argumento,
                Duracion = (float)request.Duracion,
                Fecha = (DateTime)request.Fecha,
                Genero = (int)request.Genero,
                Formato = (int)request.Formato,
                Estado = (int)request.Estado,
            };
            var data = await _repositoryAsync.AddAsync(newRegister);
            var response = new Response<int>()
            {
                Message = "El registro se ha realizado exitosamente!",
                Data = data.Id,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<FilmsDto>> GetFilmById(GetFilmByIdQuery request, CancellationToken cancellationToken)
        {
            var maestra = await _repositoryAsync.GetByIdAsync(request.Id);
            var dto = new FilmsDto();

            if (maestra != null)
            {
                dto = new FilmsDto
                {
                    Id = maestra.Id,
                    Titulo = maestra.Titulo,
                    Director = maestra.Director,
                    Argumento = maestra.Argumento,
                    Duracion = maestra.Duracion,
                    Genero = maestra.Genero,
                    Formato = maestra.Formato,
                    Fecha = maestra.Fecha,
                    Estado = maestra.Estado,
                    GeneroNavigation = _repositoryGeneroAsync.GetByIdAsync(maestra.Genero).Result,
                    FormatoNavigation = _repositoryFormatoAsync.GetByIdAsync(maestra.Formato).Result
                };
            }
            var response = new Response<FilmsDto>()
            {
                Message = "El registro se ha encontrado exitosamente!",
                Data = dto,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<int>> DeleteFilm(DeleteFilmCommand request, CancellationToken cancellationToken)
        {
            var Filmo = await _repositoryAsync.GetByIdAsync(request.Id);
            if (Filmo == null)
                throw new ApiException($"Registro no encontrado con el id {request.Id}");

            await _repositoryAsync.DeleteAsync(Filmo);
            var response = new Response<int>()
            {
                Message = "El registro se ha eliminado exitosamente!",
                Data = Filmo.Id,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<int>> UpdateFilm(UpdateFilmCommand request, CancellationToken cancellationToken)
        {
            var Filmo = await _repositoryAsync.GetByIdAsync(request.Id);
            if (Filmo == null)
                throw new ApiException($"Registro no encontrado con el id {request.Id}");

            Filmo.Titulo = request.Titulo;
            Filmo.Director = request.Director;
            Filmo.Argumento = request.Argumento;
            Filmo.Duracion = (float)request.Duracion;
            Filmo.Genero = (int)request.Genero;
            Filmo.Formato = (int)request.Formato;
            await _repositoryAsync.UpdateAsync(Filmo);
            var response = new Response<int>()
            {
                Message = "El registro se ha actualizado exitosamente!",
                Data = Filmo.Id,
                Succeeded = true
            };
            return response;
        }

        public async Task<Response<int>> ChangeStatusFilm(ChangeStatusFilmCommand request, CancellationToken cancellationToken)
        {
            var Film = await _repositoryAsync.GetByIdAsync(request.Id);
            if (Film == null)
                throw new ApiException($"Registro no encontrado con el id {request.Id}");

            Film.Estado = Film.Estado == 0 ? 1 : 0;
            await _repositoryAsync.UpdateAsync(Film);
            var response = new Response<int>()
            {
                Message = $"Se ha " + (Film.Estado == 0 ? "Habilitado" : "Deshabilitado") + " el registro: " + Film.Id,
                Data = Film.Id,
                Succeeded = true
            };
            return response;
        }
    }
}