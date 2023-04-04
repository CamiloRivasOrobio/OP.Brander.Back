using OP.Brander.Domain.Common;
using OP.Brander.Domain.Entities;

namespace OP.Brander.Application.DTOs.Formats
{
    public class FormatsDto : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string Formato { get; set; }
        public string Caracteristicas { get; set; }
        public string FormatoPelicula { get; set; }
        public virtual ICollection<Peliculas> Peliculas { get; set; }
    }
}
