using Domain.Entities;
using Domain.Enums;
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

        public async Task<Project> CreateProject(Project project)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == project.UserId);

            if (existingUser == null)
            {
                throw new InvalidOperationException("Usuário associado ao projeto não existe.");
            }

            project.Owner = existingUser;

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<List<TaskItem>> GetTaskItems(Guid projectId)
        {
            return await _context.TaskItems.Where(t => t.ProjectId == projectId).ToListAsync();
        }

        public async Task<List<Project>> GetProjectsByUser(Guid userId)
        {
            var user = await _context.Users
            .Include(u => u.Projects)
            .FirstOrDefaultAsync(u => u.Id == userId);

            return user.Projects.ToList();
        }


        public Project GetProjectById(Guid projectId)
        {
            var taskItem = _context.Projects.AsNoTracking().FirstOrDefault(p => p.ID == projectId);
            return taskItem;
        }

        public async Task<bool> DeleteProject(Project projectId)
        {
            var project = await _context.Projects
                .Include(p => p.TaskItem)
                .FirstOrDefaultAsync(p => p.ID == projectId.ID);

            if (project == null)
            {
                throw new InvalidOperationException("Projeto não encontrado.");
            }

            bool allTasksCompleted = project.TaskItem.All(task => task.Status == EStatus.Completed);

            if (!allTasksCompleted)
            {
                throw new InvalidOperationException("Não é possível remover o projeto, pois nem todas as tarefas estão concluídas.");
            }

            _context.Projects.Remove(project);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}
