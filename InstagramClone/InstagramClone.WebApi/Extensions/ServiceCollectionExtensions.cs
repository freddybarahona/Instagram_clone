using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Services;
using InstagramClone.Domain.Database.SqlServer.Context;
using InstagramClone.Domain.Interfaces.Repositories;
using InstagramClone.Infrastructure.Persistence.SqlServer.Repositories;

namespace InstagramClone.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// anade un tipo de conexion a los servicios
        /// </summary>
        /// <param name="services"></param>
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
        /// <summary>
        /// anade un tipo de conexion a los repositorios
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositories(this IServiceCollection services)
        {

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITypeUserRepository, TypeUserRepository>();
        }
        /// <summary>
        /// anade todo incluido los servicios y repositorios junto a lo necesario para que la app arranque
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddOpenApi();
            services.AddSqlServer<InstagramCloneContext>(configuration.GetConnectionString("Database"));
            services.AddServices();
            services.AddRepositories();
        }
    }
}
