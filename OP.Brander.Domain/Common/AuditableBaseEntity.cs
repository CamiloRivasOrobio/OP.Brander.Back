using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Brander.Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public DateTime? FeRegistro { get; set; }
        public DateTime? FeBaja { get; set; }
    }
}
