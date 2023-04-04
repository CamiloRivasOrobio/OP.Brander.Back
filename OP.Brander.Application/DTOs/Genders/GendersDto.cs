using OP.Brander.Domain.Common;

namespace OP.Brander.Application.DTOs.Genders
{
    public class GendersDto : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string Genero { get; set; }
    }
}
