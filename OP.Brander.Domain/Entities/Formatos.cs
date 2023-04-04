using OP.Brander.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Brander.Domain.Entities
{
    public class Formatos : AuditableBaseEntity
    {
        public Formatos()
        {
            Peliculas = new HashSet<Peliculas>();
        }

        [Key]
        public int Id { get; set; }
        public string Formato { get; set; }
        public string Caracteristicas { get; set; }
        public string FormatoPelicula { get; set; }
        public virtual ICollection<Peliculas> Peliculas { get; set; }
    }
}