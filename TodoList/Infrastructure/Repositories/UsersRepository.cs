using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;

        public UsersRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Project>> GetProjects(Guid userId)
        {
            var user = await _context.Users
             .Include(u => u.Projects)
             .FirstOrDefaultAsync(u => u.Id == userId);

            return user?.Projects.ToList();
        }
    }
}
