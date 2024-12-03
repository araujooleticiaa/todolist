using Application.Services;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _projectsService;
        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        [HttpPost]
        public async Task<ActionResult<Project>> Post(Project project)
        {
            try
            {
                var result = await _projectsService.CreateProject(project);
                return Ok(result);
            }
            catch(Exception ex) 
            {
                return StatusCode(404, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> Get(Guid projectId)
        {
            try
            {
                var result = await _projectsService.GetTaskItems(projectId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

    }
}
