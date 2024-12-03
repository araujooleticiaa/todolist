using Application.DTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
	private readonly IProjectsService _projectsService;
	private readonly IUsersService _userService;

	public ProjectsController(IProjectsService projectsService, IUsersService userService)
	{
		_projectsService = projectsService;
		_userService = userService;
	}

	// POST: /projects
	[HttpPost]
	public async Task<ActionResult<Project>> Post([FromBody] CreateProjectRequest request)
	{
		try
		{
			var user = await _userService.GetUserById(request.UserId);
			if (user == null)
			{
				return NotFound($"Esse {request.UserId} não existe.");
			}

			var project = new Project(request.Name, request.UserId)
			{
				Owner = user
			};

			var result = await _projectsService.CreateProject(project);

			return CreatedAtAction(nameof(Get), new { projectId = result.ID }, result);
		}
		catch (Exception ex)
		{
			return StatusCode(500, ex.Message);
		}
	}

	[HttpGet("{projectId}")]
	public async Task<ActionResult<List<TaskItem>>> Get(Guid projectId)
	{
		try
		{
			var result = await _projectsService.GetTaskItems(projectId);
			return Ok(result);
		}
		catch (Exception ex)
		{
			return StatusCode(500, ex.Message);
		}
	}

    [HttpDelete("{id:Guid}")]
    public ActionResult Delete([FromRoute] Guid id)
    {
        try
        {
            var result = _projectsService.DeleteProject(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
