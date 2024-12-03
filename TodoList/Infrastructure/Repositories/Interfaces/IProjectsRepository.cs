using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IProjectsRepository
    {
        Task<Project> CreateProject(Project project);
        Task<List<TaskItem>> GetTaskItems(Guid projectId);
    }
}
