using Api.Controllers;
using Application.DTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Moq;
namespace Api.UnitTests.Controllers
{
    public class TaskItemControllersTests
    {
        private readonly Mock<ITaskItemService> _taskItemServiceMock;
        private readonly TaskItemControllers _controller;

        public TaskItemControllersTests()
        {
            _taskItemServiceMock = new Mock<ITaskItemService>();
            _controller = new TaskItemControllers(_taskItemServiceMock.Object);
        }

        [Fact]
        public async Task Post_ShouldReturnOk_WhenTaskItemIsCreated()
        {
            // Arrange
            var request = new CreateTaskItemRequest
            {
                Title = "Test Task",
                Description = "Task description",
                DueDate = DateTime.UtcNow.AddDays(7),
                Status = EStatus.Pending,
                Properties = EProperty.High,
                Comments = "Initial comment",
                ProjectId = Guid.NewGuid()
            };

            var taskItem = new TaskItem(
                request.Title,
                request.Description,
                request.DueDate,
                request.Status,
                request.Properties,
                request.Comments,
                request.ProjectId
            )
            {
                ID = Guid.NewGuid()
            };

            _taskItemServiceMock.Setup(s => s.CreateTaskItem(It.IsAny<TaskItem>())).ReturnsAsync(taskItem);

            // Act
            var result = await _controller.Post(request);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedTaskItem = Assert.IsType<TaskItem>(actionResult.Value);
            Assert.Equal(taskItem.ID, returnedTaskItem.ID);
        }

        [Fact]
        public void Delete_ShouldReturnOk_WhenTaskItemIsDeleted()
        {
            // Arrange
            var taskId = Guid.NewGuid();

            _taskItemServiceMock.Setup(s => s.DeleteTaskItem(taskId)).Returns(true);

            // Act
            var result = _controller.Delete(taskId);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)actionResult.Value);
        }

        [Fact]
        public void Delete_ShouldReturnStatusCode500_WhenDeletionFails()
        {
            // Arrange
            var taskId = Guid.NewGuid();

            _taskItemServiceMock.Setup(s => s.DeleteTaskItem(taskId)).Throws(new Exception("Deletion failed"));

            // Act
            var result = _controller.Delete(taskId);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, actionResult.StatusCode);
            Assert.Equal("Deletion failed", actionResult.Value);
        }

        [Fact]
        public void UpdateTaskItem_ShouldReturnOk_WhenTaskItemIsUpdated()
        {
            // Arrange
            var taskId = Guid.NewGuid();
            var taskItem = new TaskItem("Updated Task", "Updated Description", DateTime.UtcNow.AddDays(5), EStatus.Pending, EProperty.Medium, "aqui está um comentario", Guid.NewGuid())
            {
                ID = taskId
            };

            _taskItemServiceMock.Setup(s => s.UpdateTaskItem(taskItem)).Returns(taskItem);

            // Act
            var result = _controller.UpdateTaskItem(taskItem, taskId);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateTaskItem_ShouldReturnStatusCode500_WhenUpdateFails()
        {
            // Arrange
            var taskId = Guid.NewGuid();
            var taskItem = new TaskItem("Updated Task", "Updated Description", DateTime.UtcNow.AddDays(5), EStatus.Pending, EProperty.Medium, "aqui está um comentario", Guid.NewGuid())
            {
                ID = taskId
            };

            _taskItemServiceMock.Setup(s => s.UpdateTaskItem(taskItem)).Throws(new Exception("Update failed"));

            // Act
            var result = _controller.UpdateTaskItem(taskItem, taskId);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, actionResult.StatusCode);
            Assert.Equal("Update failed", actionResult.Value);
        }
    }

}
