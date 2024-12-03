using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;

namespace Application.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IProjectsRepository _projectsRepository;
        public ProjectsService(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public async Task<Project> CreateProject(Project project)
        {
            Project newProject = new Project(project.Name, project.UserId);
            Project result = await _projectsRepository.CreateProject(newProject);
            return result;
        }

        public async Task<List<TaskItem>> GetTaskItems(Guid projectId)
        {
            var result = await _projectsRepository.GetTaskItems(projectId);

            if (result == null || !result.Any())
            {
                throw new Exception("O Projeto não tem tarefas.");
            }

            return result;
        }
    }
}
