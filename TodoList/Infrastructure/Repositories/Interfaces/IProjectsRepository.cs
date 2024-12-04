using Domain.Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IProjectsRepository
    {
        Task<Project> CreateProject(Project project);

        Task<List<TaskItem>> GetTaskItems(Guid projectId);
        Task<List<Project>> GetProjectsByUser(Guid userId);
        Project GetProjectById(Guid projectId);
        Task<bool> DeleteProject(Project projectId);
    }
}
