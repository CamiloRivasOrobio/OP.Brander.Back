using OP.Brander.Application.Parameters;
using OP.Brander.Domain.Entities;

namespace OP.Brander.Application.DTOs.Formats
{
    public class FormatsRequest : RequestParameter
    {
        public int? Id { get; set; } = null;
        public string? Formato { get; set; } = null;
        public string? Caracteristicas { get; set; } = null;
        public string? FormatoPelicula { get; set; } = null;
    }
}