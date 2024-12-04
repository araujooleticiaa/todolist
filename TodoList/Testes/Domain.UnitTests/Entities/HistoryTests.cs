using Domain.Entities;
using Domain.Enums;

namespace Domain.UnitTests.Entities
{

    public class HistoryTests
    {
        [Fact]
        public void History_ShouldBeInitializedCorrectly()
        {
            // Arrange
            var history = new History
            {
                Id = Guid.NewGuid(),
                TaskId = Guid.NewGuid(),
                ModifiedField = "Status",
                PreviousValue = "InProgress",
                NewValue = "Completed",
                ModifiedAt = DateTime.UtcNow,
                ModifiedBy = Guid.NewGuid(),
                TaskItem = new TaskItem("Task 1", "Description", DateTime.UtcNow.AddDays(5), EStatus.Pending, EProperty.Medium, "aqui está um comentario", Guid.NewGuid()),
                ModifiedUser = new User { Id = Guid.NewGuid(), Name = "User1" } 
            };


            // Assert
            Assert.NotNull(history);
            Assert.Equal(36, history.Id.ToString().Length);
            Assert.Equal("Status", history.ModifiedField);
            Assert.Equal("InProgress", history.PreviousValue);
            Assert.Equal("Completed", history.NewValue);
            Assert.True(history.ModifiedAt <= DateTime.UtcNow);
            Assert.Equal(36, history.TaskId.ToString().Length);
            Assert.NotNull(history.TaskItem);
            Assert.NotNull(history.ModifiedUser);
            Assert.Equal("User1", history.ModifiedUser.Name);
        }
    }

}
