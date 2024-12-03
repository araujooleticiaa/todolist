using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;

namespace Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<List<Project>> GetProjects(Guid userId)
        {
            var result = await _usersRepository.GetProjects(userId);

            if (result == null || !result.Any())
            {
                throw new Exception("O usuário não tem projetos.");
            }

            return result;
        }
    }
}
