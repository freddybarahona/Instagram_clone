using InstagramClone.Application.Models.Responses;

namespace InstagramClone.Application.Helpers
{
    public class ResponseHelper
    {
        public static GenericResponse<T> Create<T>(T data, string message = "Solicitud Realizada Correctamente")
        {
            return new GenericResponse<T>
            {
                Message = message,
                Data = data
            };
        }
    }
}
