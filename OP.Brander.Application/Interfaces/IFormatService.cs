using OP.Brander.Application.DTOs.Formats;
using OP.Brander.Application.Features.Format.Queries.GetAllFormatsQuery;
using OP.Brander.Application.Wrappers;

namespace OP.Brander.Application.Interfaces
{
    public interface IFormatService
    {
        Task<PagedResponse<List<FormatsDto>>> GetAllFormats(GetAllFormatsQuery request, CancellationToken cancellationToken);
    }
}