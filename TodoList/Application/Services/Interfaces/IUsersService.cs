using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IUsersService
	{
		Task<User> GetUserById(Guid UserId);

		Task<User> CreateUser(User user);
	}
}
