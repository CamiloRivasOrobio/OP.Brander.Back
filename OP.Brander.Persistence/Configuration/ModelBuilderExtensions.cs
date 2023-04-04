using Microsoft.EntityFrameworkCore;
using OP.Brander.Persistence.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Brander.Persistence.Configuration
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            DefaultFormats.Seeds(builder);
            DefaultGenders.Seeds(builder);
        }
    }
}
