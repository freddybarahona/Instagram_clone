using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Models.Requests.Posts;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.WebApi.Controllers
{   //recuerda esa comilla inicial es una ("/")
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController(IPostService service) : ControllerBase
    {
        [HttpPost("{userId:guid}")]
        public async Task<IActionResult> Create(Guid userId, [FromForm] CreatePostRequest Model)
        {
            var rsp = await service.PostCreate(Model, userId);

            return Ok(rsp);
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery] GetPostsRequest request)
        {
            var srv = await service.GetPosts(request);
            return Ok(srv);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPostsByUserId(Guid id)
        {
            var srv = await service.GetPostsByUserId(id);
            return Ok(srv);
        }
    }
}
