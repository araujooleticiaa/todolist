using Application.DTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.UnitTests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUsersService> _usersServiceMock;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _usersServiceMock = new Mock<IUsersService>();
            _controller = new UserController(_usersServiceMock.Object);
        }

        [Fact]
        public async Task Post_ShouldReturnOk_WhenUserIsCreated()
        {
            // Arrange
            var request = new CreateUserRequest
            {
                Name = "Test User",
                Role = (int)EFunction.Officer
            };

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Role = EFunction.Manager
            };

            _usersServiceMock.Setup(s => s.CreateUser(It.IsAny<User>())).ReturnsAsync(user);

            // Act
            var result = await _controller.Post(request);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUser = Assert.IsType<User>(actionResult.Value);
            Assert.Equal(user.Id, returnedUser.Id);
            Assert.Equal(user.Name, returnedUser.Name);
            Assert.Equal(user.Role, returnedUser.Role);
        }

        [Fact]
        public async Task Post_ShouldReturnStatusCode500_WhenServiceThrowsException()
        {
            // Arrange
            var request = new CreateUserRequest
            {
                Name = "Test User",
                Role = (int)EFunction.Officer
            };

            _usersServiceMock.Setup(s => s.CreateUser(It.IsAny<User>())).ThrowsAsync(new Exception("Service failure"));

            // Act
            var result = await _controller.Post(request);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, actionResult.StatusCode);
            Assert.Equal("Service failure", actionResult.Value);
        }

        [Fact]
        public async Task GetUserById_ShouldReturnOk_WhenUserExists()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new User
            {
                Id = userId,
                Name = "Test User",
                Role = EFunction.Manager
            };

            _usersServiceMock.Setup(s => s.GetUserById(userId)).ReturnsAsync(user);

            // Act
            var result = await _controller.GetUserById(userId);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUser = Assert.IsType<User>(actionResult.Value);
            Assert.Equal(user.Id, returnedUser.Id);
            Assert.Equal(user.Name, returnedUser.Name);
            Assert.Equal(user.Role, returnedUser.Role);
        }

        [Fact]
        public async Task GetUserById_ShouldReturnNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = Guid.NewGuid();

            _usersServiceMock.Setup(s => s.GetUserById(userId)).ReturnsAsync((User)null);

            // Act
            var result = await _controller.GetUserById(userId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }

}
