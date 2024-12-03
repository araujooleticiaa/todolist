using Application.DTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Entities.Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;

namespace Api.UnitTests.Controllers
{
    public class ProjectsControllerTests
    {
        private readonly Mock<IProjectsService> _projectsServiceMock;
        private readonly Mock<IUsersService> _userServiceMock;
        private readonly ProjectsController _controller;

        public ProjectsControllerTests()
        {
            _projectsServiceMock = new Mock<IProjectsService>();
            _userServiceMock = new Mock<IUsersService>();
            _controller = new ProjectsController(_projectsServiceMock.Object, _userServiceMock.Object);
        }

        [Fact]
        public async Task Post_ShouldReturnCreated_WhenUserExists()
        {
            // Arrange
            var request = new CreateProjectRequest
            {
                Name = "Test Project",
                UserId = Guid.NewGuid()
            };

            var user = new User { Id = request.UserId, Name = "Test User" };
            var project = new Project(request.Name, request.UserId) { ID = Guid.NewGuid(), Owner = user };

            _userServiceMock.Setup(s => s.GetUserById(request.UserId)).ReturnsAsync(user);
            _projectsServiceMock.Setup(s => s.CreateProject(It.IsAny<Project>())).ReturnsAsync(project);

            // Act
            var result = await _controller.Post(request);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnedProject = Assert.IsType<Project>(actionResult.Value);
            Assert.Equal(project.ID, returnedProject.ID);
            Assert.Equal(project.Name, returnedProject.Name);
        }

        [Fact]
        public async Task Post_ShouldReturnNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            var request = new CreateProjectRequest
            {
                Name = "Test Project",
                UserId = Guid.NewGuid()
            };

            _userServiceMock.Setup(s => s.GetUserById(request.UserId)).ReturnsAsync((User)null);

            // Act
            var result = await _controller.Post(request);

            // Assert
            var actionResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal($"Esse {request.UserId} não existe.", actionResult.Value);
        }

        [Fact]
        public async Task Get_ShouldReturnOk_WhenProjectExists()
        {
            // Arrange
            var projectId = Guid.NewGuid();
            var taskItems = new List<TaskItem>
            {
                new TaskItem("Updated Task", "Updated Description", DateTime.UtcNow.AddDays(5), EStatus.Pending, EProperty.Medium, "aqui está um comentario", Guid.NewGuid()),
                new TaskItem("Updated Task", "Updated Description", DateTime.UtcNow.AddDays(5), EStatus.Pending, EProperty.Medium, "aqui está um comentario", Guid.NewGuid())
            };

            _projectsServiceMock.Setup(s => s.GetTaskItems(projectId)).ReturnsAsync(taskItems);

            // Act
            var result = await _controller.Get(projectId);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedTasks = Assert.IsType<List<TaskItem>>(actionResult.Value);
            Assert.Equal(2, returnedTasks.Count);
        }

        [Fact]
        public void Delete_ShouldReturnStatusCode500_WhenDeletionFails()
        {
            // Arrange
            var projectId = Guid.NewGuid();

            _projectsServiceMock.Setup(s => s.DeleteProject(projectId)).Throws(new Exception("Deletion failed"));

            // Act
            var result = _controller.Delete(projectId);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, actionResult.StatusCode);
        }
    }

}
