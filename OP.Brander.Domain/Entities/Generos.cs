using OP.Brander.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace OP.Brander.Domain.Entities
{
    public class Generos : AuditableBaseEntity
    {
        public Generos()
        {
            Peliculas = new HashSet<Peliculas>();
        }

        [Key]
        public int Id { get; set; }
        public string Genero { get; set; }
        public virtual ICollection<Peliculas> Peliculas { get; set; }
    }
}