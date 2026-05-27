using InstagramClone.Application.Models.Requests.Posts;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.WebApi.Controllers
{
    [Route("{userId:guid}/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(Guid userId, [FromBody] CreatePostRequest Model)
        {

            return Ok("listo");
        }
    }
}
