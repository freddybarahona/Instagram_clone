using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Models.DTOs;
using InstagramClone.Application.Models.Requests.Users;
using InstagramClone.Application.Models.Responses;
using InstagramClone.Shared.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController(IUserService service) : ControllerBase
    {
        [HttpPost]//cualquiera puede crear un usuario
        [EndpointSummary("Creacion del usuario")]
        [EndpointDescription("Esta peticion crea por medio de un request la cuenta de los usuarios del aplicativo, no requiere de autorizacion")]
        [ProducesResponseType<GenericResponse<UserDTO>>(StatusCodes.Status200OK)]
        [ProducesResponseType<GenericResponse<string>>(StatusCodes.Status400BadRequest)]
        [Tags("Creation", "User")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest Model)
        {
            var rsp = await service.Create(Model);//srv = srv
            return Ok(rsp);
        }

        [HttpGet]//el buscador usara este metodo pero solo los usuarios autorizados
        [Authorize(Roles = $"{ConfigurationConstants.AUTHORIZE_REGULAR},{ConfigurationConstants.AUTHORIZE_ADMINISTRATOR},{ConfigurationConstants.AUTHORIZE_CONSTANT_CREATOR},{ConfigurationConstants.AUTHORIZE_BUSINESS_ACCOUNT}")]
        [HttpPost]//cualquiera puede crear un usuario
        [EndpointSummary("Obtener usuario")]
        [EndpointDescription("Esta peticion permite obtener la informacion de uno o mas usuarios por medio de un query y requiere autorizacion por role")]
        [ProducesResponseType<GenericResponse<List<UserDTO>>>(StatusCodes.Status200OK)]
        [ProducesResponseType<GenericResponse<string>>(StatusCodes.Status400BadRequest)]
        [Tags("Obtener", "User", "Query", "Request", "Params", "roles")]
        public async Task<IActionResult> GetUser([FromQuery] GetUsersRequest request)
        {
            var rsp = await service.GetUser(request);
            return Ok(rsp);
        }



        [HttpGet("{id:guid}")]//este metodo es solo para administradores
        [Authorize(Roles = $"{ConfigurationConstants.AUTHORIZE_REGULAR},{ConfigurationConstants.AUTHORIZE_ADMINISTRATOR},{ConfigurationConstants.AUTHORIZE_CONSTANT_CREATOR},{ConfigurationConstants.AUTHORIZE_BUSINESS_ACCOUNT}")]
        [EndpointSummary("Obtener usuario en base a su ID")]
        [EndpointDescription("Esta peticion permite obtener la informacion de un usuario por su ID, requiere autorizacion por medio de roles de usuario")]
        [ProducesResponseType<GenericResponse<UserDTO>>(StatusCodes.Status200OK)]
        [ProducesResponseType<GenericResponse<string>>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<GenericResponse<string>>(StatusCodes.Status404NotFound)]
        [Tags("Obtener", "User", "ID", "roles")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var rsp = await service.GetUserById(id);
            return Ok(rsp);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = $"{ConfigurationConstants.AUTHORIZE_REGULAR},{ConfigurationConstants.AUTHORIZE_ADMINISTRATOR},{ConfigurationConstants.AUTHORIZE_CONSTANT_CREATOR},{ConfigurationConstants.AUTHORIZE_BUSINESS_ACCOUNT}")]
        [EndpointSummary("Hacer soft delete de usuario existente")]
        [EndpointDescription("Esta peticion permite en base al Id del usuario generar un soft delete donde se actualiza la tabla de usuarios se debe autenticar por JWT token")]
        [ProducesResponseType<GenericResponse<UserDTO>>(StatusCodes.Status200OK)]
        [ProducesResponseType<GenericResponse<string>>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<GenericResponse<string>>(StatusCodes.Status404NotFound)]
        [Tags("Soft Delete", "User", "ID", "roles")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var rsp = await service.DeleteUser(id);
            return Ok(rsp);
        }
    }
}
