using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest Model)
        {
            var rsp = userService.Create(Model);//rsp = response
            return Ok(rsp);
        }

        [HttpPut("data/{id:guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserRequest model)
        {
            var rsp = userService.UpdateUser(id, model);
            return Ok(rsp);
        }

        [HttpPut("password/{id:guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdatePasswordUserRequest model)
        {
            var rsp = userService.UpdatePasswordUser(id, model);
            return Ok(rsp);
        }
    }
}
