using Application.DTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
	private readonly IUsersService _usersService;

	public UserController(IUsersService usersService)
	{
		_usersService = usersService;
	}

	[HttpPost]
	public async Task<ActionResult<User>> Post([FromBody] CreateUserRequest request)
	{
		try
		{
			var user = new User
			{
				Name = request.Name,
				Role = (EFunction)request.Role 
			};

			var createdUser = await _usersService.CreateUser(user);
			return Ok(createdUser);
		}
		catch (Exception ex)
		{
			return StatusCode(500, ex.Message); 
		}
	}

	[HttpGet("{userId}")]
	public async Task<ActionResult<User>> GetUserById(Guid userId)
	{
		var user = await _usersService.GetUserById(userId);
		if (user == null)
		{
			return NotFound();
		}
		return Ok(user);
	}
}
