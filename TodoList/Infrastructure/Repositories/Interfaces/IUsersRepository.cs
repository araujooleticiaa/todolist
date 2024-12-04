using Domain.Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> GetUserById(Guid userId);   
        Task<User> CreateUser(User user);
    }
}
