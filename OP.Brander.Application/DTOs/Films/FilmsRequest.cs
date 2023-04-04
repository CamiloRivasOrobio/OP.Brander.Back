using OP.Brander.Application.Parameters;
using OP.Brander.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Brander.Application.DTOs.Films
{
    public class FilmsRequest : RequestParameter
    {
        public int? Id { get; set; } = null;
        public string? Titulo { get; set; } = null;
        public DateTime? Fecha { get; set; } = null;
        public string? Director { get; set; } = null;
        public string? Argumento { get; set; } = null;
        public float? Duracion { get; set; } = null;
        public int? Genero { get; set; } = null;
        public int? Formato { get; set; } = null;
        public int? Estado { get; set; } = null;
    }
}
