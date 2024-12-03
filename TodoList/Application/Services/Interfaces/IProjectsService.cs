
using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IProjectsService
    {
        Task<Project> CreateProject(Project project);
        Task<List<TaskItem>> GetTaskItems(Guid projectId);
    }
}
