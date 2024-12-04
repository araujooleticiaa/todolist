using Application.Services;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Repositories.Interfaces;
using Moq;
using System.Threading.Tasks;

namespace Application.UnitTests.Service
{
    public class TaskItemServiceTests
    {
        private readonly Mock<ITaskItemRepository> _taskItemRepositoryMock;
        private readonly TaskItemService _service;

        public TaskItemServiceTests()
        {
            _taskItemRepositoryMock = new Mock<ITaskItemRepository>();
            _service = new TaskItemService(_taskItemRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateTaskItem_ShouldReturnCreatedTaskItem()
        {
            // Arrange
            var taskItem = new TaskItem("Updated Task", "Updated Description", DateTime.UtcNow.AddDays(5), EStatus.Pending, EProperty.Medium, "aqui está um comentario", Guid.NewGuid())
            {
                ID = Guid.NewGuid()
            };

            _taskItemRepositoryMock
                .Setup(repo => repo.CreateTaskItem(It.IsAny<TaskItem>()))
                .ReturnsAsync(taskItem);

            // Act
            var result = await _service.CreateTaskItem(taskItem);

            // Assert
            Assert.Equal(taskItem.ID, result.ID);
            Assert.Equal(taskItem.Title, result.Title);
            Assert.Equal(taskItem.Description, result.Description);
            _taskItemRepositoryMock.Verify(repo => repo.CreateTaskItem(It.IsAny<TaskItem>()), Times.Once);
        }

        [Fact]
        public void GetTaskItemById_ShouldReturnTaskItem_WhenTaskExists()
        {
            // Arrange
            var taskItemId = Guid.NewGuid();
            var taskItem = new TaskItem("Task Title", "Task Description", DateTime.Now, EStatus.Completed, EProperty.Medium, "aqui está um comentario", Guid.NewGuid())
            {
                ID = taskItemId
            };

            _taskItemRepositoryMock
                .Setup(repo => repo.GetTaskItemById(taskItemId))
                .Returns(taskItem);

            // Act
            var result = _service.GetTaskItemById(taskItemId);

            // Assert
            Assert.Equal(taskItemId, result.ID);
            Assert.Equal(taskItem.Title, result.Title);
            _taskItemRepositoryMock.Verify(repo => repo.GetTaskItemById(taskItemId), Times.Once);
        }

        [Fact]
        public void GetTaskItemById_ShouldReturnNull_WhenTaskDoesNotExist()
        {
            // Arrange
            var taskItemId = Guid.NewGuid();

            _taskItemRepositoryMock
                .Setup(repo => repo.GetTaskItemById(taskItemId))
                .Returns((TaskItem)null);

            // Act
            var result = _service.GetTaskItemById(taskItemId);

            // Assert
            Assert.Null(result);
            _taskItemRepositoryMock.Verify(repo => repo.GetTaskItemById(taskItemId), Times.Once);
        }

        //[Fact]
        //public bool DeleteTaskItem_ShouldReturnTrue_WhenTaskItemDeletedSuccessfully()
        //{
        //    // Arrange
        //    var taskItemId = Guid.NewGuid();
        //    var taskItem = new TaskItem("Task Title", "Task Description", DateTime.Now, TaskStatus.Pending, new Dictionary<string, string>(), new List<string>(), taskItemId);

        //    _taskItemRepositoryMock
        //        .Setup(repo => repo.GetTaskItemById(taskItemId))
        //        .Returns(taskItem);

        //    _taskItemRepositoryMock
        //        .Setup(repo => repo.DeleteTaskItem(taskItem))
        //        .Returns(true);

        //    // Act
        //    var result = _service.DeleteTaskItem(taskItemId);

        //    // Assert
        //    Assert.True(result);
        //    _taskItemRepositoryMock.Verify(repo => repo.GetTaskItemById(taskItemId), Times.Once);
        //    _taskItemRepositoryMock.Verify(repo => repo.DeleteTaskItem(taskItem), Times.Once);
        //}

        //[Fact]
        //public bool DeleteTaskItem_ShouldReturnFalse_WhenTaskItemNotFound()
        //{
        //    // Arrange
        //    var taskItemId = Guid.NewGuid();

        //    _taskItemRepositoryMock
        //        .Setup(repo => repo.GetTaskItemById(taskItemId))
        //        .Returns((TaskItem)null);

        //    // Act
        //    var result = _service.DeleteTaskItem(taskItemId);

        //    // Assert
        //    Assert.False(result);
        //    _taskItemRepositoryMock.Verify(repo => repo.GetTaskItemById(taskItemId), Times.Once);
        //    _taskItemRepositoryMock.Verify(repo => repo.DeleteTaskItem(It.IsAny<TaskItem>()), Times.Never);
        //}

        //[Fact]
        //public TaskItem UpdateTaskItem_ShouldReturnUpdatedTaskItem()
        //{
        //    // Arrange
        //    var taskItem = new TaskItem("Task Title", "Task Description", DateTime.Now, TaskStatus.Pending, new Dictionary<string, string>(), new List<string>(), Guid.NewGuid())
        //    {
        //        ID = Guid.NewGuid()
        //    };

        //    var updatedTaskItem = new TaskItem("Updated Task", "Updated Description", DateTime.Now, TaskStatus.Completed, new Dictionary<string, string>(), new List<string>(), taskItem.ID);

        //    _taskItemRepositoryMock
        //        .Setup(repo => repo.UpdateTaskItem(It.IsAny<TaskItem>()))
        //        .Returns(updatedTaskItem);

        //    // Act
        //    var result = _service.UpdateTaskItem(taskItem);

        //    // Assert
        //    Assert.Equal(updatedTaskItem.ID, result.ID);
        //    Assert.Equal(updatedTaskItem.Title, result.Title);
        //    Assert.Equal(updatedTaskItem.Description, result.Description);
        //    _taskItemRepositoryMock.Verify(repo => repo.UpdateTaskItem(It.IsAny<TaskItem>()), Times.Once);
        //}
    }
}
