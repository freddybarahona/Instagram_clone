using InstagramClone.WebApi.Middlewares;

namespace InstagramClone.WebApi.Extensions
{
    public static class FinalsExtensions
    {
        public static void AddFinals(this IApplicationBuilder app, IEndpointRouteBuilder endpoints)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            endpoints.MapControllers();
        }
    }
}
