using OP.Brander.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Brander.Domain.Entities
{
    public class Peliculas : AuditableBaseEntity
    {

        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string Director { get; set; }
        public string Argumento { get; set; }
        public float Duracion { get; set; }
        public int Genero { get; set; }
        public int Formato { get; set; }
        public int? Estado { get; set; } = null;
        public virtual Generos? GeneroNavigation { get; set; } = null;
        public virtual Formatos? FormatoNavigation { get; set; } = null;
    }
} 