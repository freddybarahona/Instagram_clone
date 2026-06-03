using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Models.DTOs;
using InstagramClone.Application.Models.Requests.Posts;
using InstagramClone.Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.WebApi.Controllers
{   //recuerda esa comilla inicial es una ("/")
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController(IPostService service) : ControllerBase
    {
        [HttpPost("{userId:guid}")]
        [EndpointSummary("Crear publicacion")]
        [EndpointDescription("Esta peticion permite crear una publicacion por parte de un usuario, requiere autorizacion por medio de roles de usuario")]
        [ProducesResponseType<GenericResponse<PostDTO>>(StatusCodes.Status200OK)]
        [ProducesResponseType<GenericResponse<string>>(StatusCodes.Status400BadRequest)]
        [Tags("Crear", "Post", "User", "ID", "roles")]
        public async Task<IActionResult> Create(Guid userId, [FromForm] CreatePostRequest Model)
        {
            var rsp = await service.PostCreate(Model, userId);

            return Ok(rsp);
        }

        [HttpGet]
        [EndpointSummary("Obtener publicaciones por filtro")]
        [EndpointDescription("Esta peticion permite obtener las publicaciones por medio de busquedas a traves de hashtags, descripcion o nombre de usuario ")]
        [ProducesResponseType<GenericResponse<PostDTO>>(StatusCodes.Status200OK)]
        [Tags("Obtener", "Post", "Filtro", "Query", "roles")]
        public async Task<IActionResult> GetPosts([FromQuery] GetPostsRequest request)
        {
            var srv = await service.GetPosts(request);
            return Ok(srv);
        }

        [HttpGet("{id:guid}")]
        [EndpointSummary("Obtener publicaciones por ID de usuario")]
        [EndpointDescription("Esta peticion permite obtener las publicaciones de un usuario en base a su ID, requiere autorizacion por medio de roles de usuario")]
        [ProducesResponseType<GenericResponse<PostDTO>>(StatusCodes.Status200OK)]
        [ProducesResponseType<GenericResponse<string>>(StatusCodes.Status404NotFound)]
        [Tags("Obtener", "Post", "User", "ID", "roles")]
        public async Task<IActionResult> GetPostsByUserId(Guid id)
        {
            var srv = await service.GetPostsByUserId(id);
            return Ok(srv);
        }
    }
}
