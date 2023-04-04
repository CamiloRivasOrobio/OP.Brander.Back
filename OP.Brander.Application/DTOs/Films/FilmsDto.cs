using OP.Brander.Domain.Common;
using OP.Brander.Domain.Entities;

namespace OP.Brander.Application.DTOs.Films
{
    public class FilmsDto : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string Director { get; set; }
        public string Argumento { get; set; }
        public float Duracion { get; set; }
        public int Genero { get; set; }
        public int Formato { get; set; }
        public int? Estado { get; set; } = null;
        public virtual Generos GeneroNavigation { get; set; }
        public virtual Formatos FormatoNavigation { get; set; }
    }
}