using Domain.Entities;
using Domain.Enums;

namespace Domain.UnitTests.Entities
{
    public class TaskItemTests
    {
        [Fact]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var title = "Task 1";
            var description = "Description for Task 1";
            var dueDate = DateTime.UtcNow.AddDays(5);
            var status = EStatus.Pending; 
            var properties = EProperty.High;
            var comments = "Some comments";
            var projectId = Guid.NewGuid();

            // Act
            var taskItem = new TaskItem(title, description, dueDate, status, properties, comments, projectId);

            // Assert
            Assert.NotNull(taskItem);
            Assert.Equal(title, taskItem.Title);
            Assert.Equal(description, taskItem.Description); 
            Assert.Equal(dueDate, taskItem.DueDate);
            Assert.Equal(status, taskItem.Status); 
            Assert.Equal(properties, taskItem.Properties);
            Assert.Equal(comments, taskItem.Comments); 
            Assert.Equal(projectId, taskItem.ProjectId);
            Assert.NotNull(taskItem.Histories);
            Assert.Empty(taskItem.Histories);
        }

        [Fact]
        public void TaskItem_ShouldInitializeWithEmptyHistories()
        {
            // Arrange
            var title = "Task 2";
            var description = "Description for Task 2";
            var dueDate = DateTime.UtcNow.AddDays(10);
            var status = EStatus.Completed; 
            var properties = EProperty.Low;
            var comments = "Task is in progress";
            var projectId = Guid.NewGuid();

            // Act
            var taskItem = new TaskItem(title, description, dueDate, status, properties, comments, projectId);

            // Assert
            Assert.NotNull(taskItem.Histories);
            Assert.Empty(taskItem.Histories);
        }
    }

}
