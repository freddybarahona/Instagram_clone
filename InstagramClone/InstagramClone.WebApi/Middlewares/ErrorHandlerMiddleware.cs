using InstagramClone.Application.Helpers;
using InstagramClone.Application.Models.Responses;

namespace InstagramClone.WebApi.Middlewares
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsJsonAsync(ManageException(context, ex, StatusCodes.Status500InternalServerError));
            }
        }
        public GenericResponse<string> ManageException(HttpContext context, Exception exception, int statusCode)
        {
            var rsp = ResponseHelper.Create
                (data: exception.Message,
                message: exception.Message,
                errors: [exception.Message]
                );
            context.Response.StatusCode = statusCode;
            return rsp;
        }
    }
}
