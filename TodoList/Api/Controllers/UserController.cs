using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> Get(Guid id)
        {
            try
            {
                //var result = await _usersService.GetProjects(id);
                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server failure.");
            }
        }
    }
}
