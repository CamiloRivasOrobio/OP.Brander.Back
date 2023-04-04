using OP.Brander.Application.Parameters;

namespace OP.Brander.Application.DTOs.Genders
{
    public class GendersRequest : RequestParameter
    {
        public int? Id { get; set; } = null;
        public string? Genero { get; set; } = null;
    }
}