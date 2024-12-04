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

		public async Task<User> GetUserById(Guid userID)
		{
			User user = await _usersRepository.GetUserById(userID);
			return user;	

		}

		public async Task<User> CreateUser(User user)
		{
			var createdUser = await _usersRepository.CreateUser(user);
			if (createdUser == null)
			{
				throw new Exception("O Usuario não foi criado.");

			}

			return createdUser;
		}
	}

}
