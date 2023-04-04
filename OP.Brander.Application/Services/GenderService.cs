using AutoMapper;
using OP.Brander.Application.DTOs.Genders;
using OP.Brander.Application.Exceptions;
using OP.Brander.Application.Features.Gender.Queries.GetAllGendersQuery;
using OP.Brander.Application.Interfaces;
using OP.Brander.Application.Specifications;
using OP.Brander.Application.Wrappers;
using OP.Brander.Domain.Entities;
using NPOI.POIFS.Crypt.Dsig;

namespace OP.Brander.Application.Services
{
    public class GenderService : IGenderService
    {
        private readonly IRepositoryAsync<Domain.Entities.Generos> _repositoryAsync;
        private readonly IMapper _mapper;

        public GenderService(IRepositoryAsync<Generos> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<PagedResponse<List<GendersDto>>> GetAllGenders(GetAllGendersQuery request, CancellationToken cancellationToken)
        {
            var Genders = await _repositoryAsync.ListAsync(new PagedGenderSpecification(request.PageSize, request.PageNumber, request.Id, request.Genero));
            var GendersCount = await _repositoryAsync.CountAsync(new PagedGenderSpecification(null, null, request.Id, request.Genero));
            var GendersDto = new List<GendersDto>();
            if (Genders.Count > 0)
            {
                GendersDto = (from data in Genders
                              select new GendersDto
                              {
                                  Id = data.Id,
                                  Genero = data.Genero
                              }).ToList();
            }
            return new PagedResponse<List<GendersDto>>(GendersDto, request.PageNumber, request.PageSize, GendersCount);
        }
    }
}