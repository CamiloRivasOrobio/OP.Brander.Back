using OP.Brander.WebAPI.Middleware;

namespace OP.Brander.WebAPI.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandleMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
