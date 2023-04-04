using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OP.Brander.Application.Behaviours;
using OP.Brander.Application.Interfaces;
using OP.Brander.Application.Services;
using System.Reflection;

namespace OP.Brander.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            #region Services
            services.AddTransient<IFilmService, FilmService>();
            services.AddTransient<IFormatService, FormatService>();
            services.AddTransient<IGenderService, GenderService>();
            #endregion
        }
    }
}