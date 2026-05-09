using InstagramClone.Application.Helpers;
using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Services;
using InstagramClone.Domain.Database.SqlServer.Context;
using InstagramClone.Domain.Interfaces.Repositories;
using InstagramClone.Infrastructure.Persistence.SqlServer.Repositories;
using InstagramClone.Shared.Constants;
using InstagramClone.WebApi.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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

        public static void AddMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlerMiddleware>();
        }

        public static void AddLogging(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .File(Path.Combine(Directory.GetCurrentDirectory(), "Logs/log.txt"), rollingInterval: RollingInterval.Day)
                .WriteTo.Console()
                .CreateLogger();
        }
        /// <summary>
        /// anade todo incluido los servicios y repositorios junto a lo necesario para que la app arranque
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = (errorContext) =>
                {
                    var errors = errorContext.ModelState.Values.SelectMany(value => value.Errors.Select(error => error.ErrorMessage)).ToList();
                    var rsp = ResponseHelper.Create(
                        data: ValidationConstants.VALIDATION_MESSAGE,
                        errors: errors,
                        message: ValidationConstants.VALIDATION_MESSAGE);
                    return new BadRequestObjectResult(rsp);
                };
            });
            services.AddOpenApi();
            services.AddSqlServer<InstagramCloneContext>(configuration.GetConnectionString("Database"));
            services.AddRepositories();
            services.AddServices();
            services.AddMiddlewares();
            services.AddLogging();
        }
    }
}
