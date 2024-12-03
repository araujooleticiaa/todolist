using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly DataContext _context;

        public ProjectsRepository(DataContext context)
        {
            _context = context;
        }

        public Project CreateProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();

            return project;
        }

        public async Task<List<TaskItem>> GetTaskItems(Guid projectId)
        {
            var projectAndTasks = await _context.Projects
             .Include(u => u.TaskItem)
             .FirstOrDefaultAsync(u => u.Id == projectId);

            return projectAndTasks?.TaskItem.ToList();
        }
    }
}
