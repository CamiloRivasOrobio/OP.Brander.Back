using AutoMapper;
using OP.Brander.Application.DTOs.Formats;
using OP.Brander.Application.Exceptions;
using OP.Brander.Application.Features.Format.Queries.GetAllFormatsQuery;
using OP.Brander.Application.Interfaces;
using OP.Brander.Application.Specifications;
using OP.Brander.Application.Wrappers;
using OP.Brander.Domain.Entities;

namespace OP.Brander.Application.Services
{
    public class FormatService : IFormatService
    {
        private readonly IRepositoryAsync<Domain.Entities.Formatos> _repositoryAsync;
        private readonly IMapper _mapper;

        public FormatService(IRepositoryAsync<Formatos> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<PagedResponse<List<FormatsDto>>> GetAllFormats(GetAllFormatsQuery request, CancellationToken cancellationToken)
        {
            var Formats = await _repositoryAsync.ListAsync(new PagedFormatSpecification(request.PageSize, request.PageNumber, request.Id, request.Formato, request.Caracteristicas, request.FormatoPelicula));
            var FormatsCount = await _repositoryAsync.CountAsync(new PagedFormatSpecification(null, null, request.Id, request.Formato, request.Caracteristicas, request.FormatoPelicula));
            var FormatsDto = new List<FormatsDto>();
            if (Formats.Count > 0)
            {
                FormatsDto = (from data in Formats
                              select new FormatsDto
                              {
                                  Id = data.Id,
                                  Caracteristicas = data.Caracteristicas,
                                  FormatoPelicula = data.FormatoPelicula,
                                  Formato = data.Formato
                              }).ToList();
            }
            return new PagedResponse<List<FormatsDto>>(FormatsDto, request.PageNumber, request.PageSize, FormatsCount);
        }
    }
}