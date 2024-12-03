using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly DataContext _context;

        public UsersService(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //public async Task<List<Project>> GetProjects(Guid userId)
        //{
        //    var user = await _context.Users.Include(u => u.Projects)
        //    .FirstOrDefaultAsync(u => u.Id == userId);

        //    return user?.Projects.ToList() ?? new List<Project>();
        //}
    }
}
