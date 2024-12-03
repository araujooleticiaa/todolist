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
			Project result = await _projectsRepository.CreateProject(project);
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

		public async Task<List<Project>> GetProjects(Guid userId)
		{
			var result = await _projectsRepository.GetProjectsByUser(userId);

			if (result == null)
			{
				throw new Exception("O usuário não tem projetos.");
			}

			return result;
		}

        public Project GetProjectById(Guid projectId)
        {
            Project project = _projectsRepository.GetProjectById(projectId);
            return project;
        }

        public Task<bool> DeleteProject(Guid projectId)
        {
            Project project = GetProjectById(projectId);
            var result = _projectsRepository.DeleteProject(project);

            return result;
        }
    }
}
