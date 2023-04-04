using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OP.Brander.Application.Interfaces;

namespace OP.Brander.Shared
{
    public static class ServiceExtensions
    {
        public static void AddSharedInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
