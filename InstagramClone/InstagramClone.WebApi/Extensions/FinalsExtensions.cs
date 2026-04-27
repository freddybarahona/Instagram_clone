namespace InstagramClone.WebApi.Extensions
{
    public static class FinalsExtensions
    {
        public static void AddFinals(this IApplicationBuilder app, IEndpointRouteBuilder endpoints)
        {
            app.UseHttpsRedirection();
            app.UseAuthorization();
            endpoints.MapControllers();
        }
    }
}
