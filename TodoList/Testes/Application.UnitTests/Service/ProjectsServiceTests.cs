using Application.Services;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Repositories.Interfaces;
using Moq;

namespace Application.UnitTests.Service
{
    public class ProjectsServiceTests
    {
        private readonly Mock<IProjectsRepository> _projectsRepositoryMock;
        private readonly ProjectsService _service;

        public ProjectsServiceTests()
        {
            _projectsRepositoryMock = new Mock<IProjectsRepository>();
            _service = new ProjectsService(_projectsRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateProject_ShouldReturnCreatedProject()
        {
            // Arrange
            var project = new Project("Test Project", Guid.NewGuid()) { ID = Guid.NewGuid() };

            _projectsRepositoryMock
                .Setup(repo => repo.CreateProject(It.IsAny<Project>()))
                .ReturnsAsync(project);

            // Act
            var result = await _service.CreateProject(project);

            // Assert
            Assert.Equal(project.ID, result.ID);
            Assert.Equal(project.Name, result.Name);
            _projectsRepositoryMock.Verify(repo => repo.CreateProject(It.IsAny<Project>()), Times.Once);
        }

        [Fact]
        public async Task GetTaskItems_ShouldReturnTaskItems_WhenProjectHasTasks()
        {
            // Arrange
            var projectId = Guid.NewGuid();
            var taskItems = new List<TaskItem>
            {
                new TaskItem("Task 1", "Description", DateTime.UtcNow.AddDays(5), EStatus.Pending, EProperty.Medium, "aqui está um comentario", Guid.NewGuid()),
                new TaskItem("Task 2", "Description", DateTime.UtcNow.AddDays(5), EStatus.Pending, EProperty.Medium, "aqui está um comentario", Guid.NewGuid())
            };

            _projectsRepositoryMock
                .Setup(repo => repo.GetTaskItems(projectId))
                .ReturnsAsync(taskItems);

            // Act
            var result = await _service.GetTaskItems(projectId);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, t => t.Title == "Task 1");
            _projectsRepositoryMock.Verify(repo => repo.GetTaskItems(projectId), Times.Once);
        }

        [Fact]
        public async Task GetTaskItems_ShouldThrowException_WhenProjectHasNoTasks()
        {
            // Arrange
            var projectId = Guid.NewGuid();

            _projectsRepositoryMock
                .Setup(repo => repo.GetTaskItems(projectId))
                .ReturnsAsync(new List<TaskItem>());

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _service.GetTaskItems(projectId));
            Assert.Equal("O Projeto não tem tarefas.", exception.Message);
        }

        [Fact]
        public async Task GetProjects_ShouldReturnProjects_WhenUserHasProjects()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var projects = new List<Project>
            {
                new Project("Project 1", userId) { ID = Guid.NewGuid() },
                new Project("Project 2", userId) { ID = Guid.NewGuid() }
            };

            _projectsRepositoryMock
                .Setup(repo => repo.GetProjectsByUser(userId))
                .ReturnsAsync(projects);

            // Act
            var result = await _service.GetProjects(userId);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, p => p.Name == "Project 1");
            _projectsRepositoryMock.Verify(repo => repo.GetProjectsByUser(userId), Times.Once);
        }

        [Fact]
        public async Task GetProjects_ShouldThrowException_WhenUserHasNoProjects()
        {
            // Arrange
            var userId = Guid.NewGuid();

            _projectsRepositoryMock
                .Setup(repo => repo.GetProjectsByUser(userId))
                .ReturnsAsync((List<Project>)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _service.GetProjects(userId));
            Assert.Equal("O usuário não tem projetos.", exception.Message);
        }

        [Fact]
        public void GetProjectById_ShouldReturnProject_WhenProjectExists()
        {
            // Arrange
            var projectId = Guid.NewGuid();
            var project = new Project("Existing Project", Guid.NewGuid()) { ID = projectId };

            _projectsRepositoryMock
                .Setup(repo => repo.GetProjectById(projectId))
                .Returns(project);

            // Act
            var result = _service.GetProjectById(projectId);

            // Assert
            Assert.Equal(project.ID, result.ID);
            Assert.Equal(project.Name, result.Name);
            _projectsRepositoryMock.Verify(repo => repo.GetProjectById(projectId), Times.Once);
        }

        [Fact]
        public async Task DeleteProject_ShouldReturnTrue_WhenProjectIsDeleted()
        {
            // Arrange
            var projectId = Guid.NewGuid();
            var project = new Project("To Delete", Guid.NewGuid()) { ID = projectId };

            _projectsRepositoryMock
                .Setup(repo => repo.GetProjectById(projectId))
                .Returns(project);

            _projectsRepositoryMock
                .Setup(repo => repo.DeleteProject(project))
                .ReturnsAsync(true);

            // Act
            var result = await _service.DeleteProject(projectId);

            // Assert
            Assert.True(result);
            _projectsRepositoryMock.Verify(repo => repo.GetProjectById(projectId), Times.Once);
            _projectsRepositoryMock.Verify(repo => repo.DeleteProject(project), Times.Once);
        }
    }

}
