using Microsoft.AspNetCore.Mvc;
using StudySprint.Services.DTOs;
using StudySprint.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace StudySprint.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? sortBy = null)
        {
            var result = await _userService.GetAll(page, pageSize, sortBy);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreateUserDto dto)
        {
            var result = await _userService.Create(dto);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult>
        GetById(int id)
        {
            var user = await _userService.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateUserDto dto)
        {
            var result =await _userService.Update(id, dto);

            if (!result)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult> Search([FromQuery] string? username, [FromQuery] string? role)
        {
            var result = await _userService.Search(username, role);

            return Ok(result);
        }
    }
}