using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Application.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly DataContext _context;

        public ProjectsService(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Project> CreateProject(Project project)
        {
            try
            {
                var createProject = new Project
                {
                    Name = project.Name,
                    UserId = project.UserId,
                };

                await _context.Projects.AddAsync(createProject);
                //await _context.Tasks.AddAsync(createProject.Tasks);

                await _context.SaveChangesAsync();

                return createProject;
            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException("Parameter index is out of range.", ex);
            }

        }
    }
}
