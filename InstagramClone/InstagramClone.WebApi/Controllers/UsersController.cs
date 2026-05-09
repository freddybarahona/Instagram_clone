using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Models.Requests.Users;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest Model)
        {
            var srv = await service.Create(Model);//srv = srv
            return Ok(srv);
        }

        [HttpGet]
        public async Task<IActionResult> GetUser([FromQuery] GetUsersRequest request)
        {
            var srv = await service.GetUser(request);
            return Ok(srv);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var srv = await service.GetUserById(id);
            return Ok(srv);
        }
    }
}
