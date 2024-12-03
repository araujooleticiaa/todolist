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

        //[HttpPost]
        //public async Task<ActionResult<Project>> CreateTransactions(Project project)
        //{
        //    try
        //    {
        //        var result = await _projectsService.CreateProject(project);
        //        return Ok(result);
        //    }
        //    catch
        //    {
        //        return StatusCode(500, "Internal server failure.");
        //    }
        //}

    }
}
