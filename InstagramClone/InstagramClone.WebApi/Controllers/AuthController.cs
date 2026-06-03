using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Models.Requests.Auth;
using InstagramClone.Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService service) : ControllerBase
    {
        [HttpPost("login")]
        [EndpointSummary("Autenticar acceso de usuarios")]
        [EndpointDescription("Esta peticion permite autenticar el acceso de los usuarios del aplicativo, no requiere de autorizacion")]
        [ProducesResponseType<GenericResponse<string>>(StatusCodes.Status200OK)]
        [ProducesResponseType<GenericResponse<string>>(StatusCodes.Status400BadRequest)]
        [Tags("Auth", "User", "email", "password")]
        public async Task<IActionResult> Login([FromBody] LoginAuthRequest model)
        {
            var srv = await service.Login(model);
            return Ok(srv);
        }
    }
}
