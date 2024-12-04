using Application.Services;
using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;
using Moq;
namespace Application.UnitTests.Service
{
    public class UsersServiceTests
    {
        private readonly Mock<IUsersRepository> _usersRepositoryMock;
        private readonly IUsersService _service;

        public UsersServiceTests()
        {
            _usersRepositoryMock = new Mock<IUsersRepository>();
            _service = new UsersService(_usersRepositoryMock.Object);
        }

        [Fact]
        public async Task GetUserById_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new User
            {
                Id = userId,
                Name = "John Doe",
                Role = Domain.Enums.EFunction.Officer
            };

            _usersRepositoryMock
                .Setup(repo => repo.GetUserById(userId))
                .ReturnsAsync(user);

            // Act
            var result = await _service.GetUserById(userId);

            // Assert
            Assert.Equal(userId, result.Id);
            Assert.Equal("John Doe", result.Name);
            _usersRepositoryMock.Verify(repo => repo.GetUserById(userId), Times.Once);
        }

        [Fact]
        public async Task GetUserById_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = Guid.NewGuid();

            _usersRepositoryMock
                .Setup(repo => repo.GetUserById(userId))
                .ReturnsAsync((User)null);

            // Act
            var result = await _service.GetUserById(userId);

            // Assert
            Assert.Null(result);
            _usersRepositoryMock.Verify(repo => repo.GetUserById(userId), Times.Once);
        }

        [Fact]
        public async Task CreateUser_ShouldReturnCreatedUser_WhenUserIsCreatedSuccessfully()
        {
            // Arrange
            var user = new User
            {
                Name = "Jane Doe",
                Role = Domain.Enums.EFunction.Manager
            };

            var createdUser = new User
            {
                Id = Guid.NewGuid(),
                Name = "Jane Doe",
                Role = Domain.Enums.EFunction.Manager
            };

            _usersRepositoryMock
                .Setup(repo => repo.CreateUser(It.IsAny<User>()))
                .ReturnsAsync(createdUser);

            // Act
            var result = await _service.CreateUser(user);

            // Assert
            Assert.Equal(createdUser.Id, result.Id);
            Assert.Equal(createdUser.Name, result.Name);
            Assert.Equal(createdUser.Role, result.Role);
            _usersRepositoryMock.Verify(repo => repo.CreateUser(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task CreateUser_ShouldThrowException_WhenUserCreationFails()
        {
            // Arrange
            var user = new User
            {
                Name = "Jane Doe",
                Role = Domain.Enums.EFunction.Manager
            };

            _usersRepositoryMock
                .Setup(repo => repo.CreateUser(It.IsAny<User>()))
                .ReturnsAsync((User)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _service.CreateUser(user));
            Assert.Equal("O Usuario não foi criado.", exception.Message);
            _usersRepositoryMock.Verify(repo => repo.CreateUser(It.IsAny<User>()), Times.Once);
        }
    }

}
