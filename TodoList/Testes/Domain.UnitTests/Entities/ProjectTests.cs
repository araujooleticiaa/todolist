using Domain.Entities;
namespace Domain.UnitTests.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var name = "Project A";
            var userId = Guid.NewGuid();

            // Act
            var project = new Project(name, userId);

            // Assert
            Assert.NotNull(project); 
            Assert.Equal(name, project.Name);
            Assert.Equal(userId, project.UserId); 
            Assert.NotEqual(Guid.Empty, project.ID);
            Assert.NotNull(project.TaskItem); 
        }

        [Fact]
        public void Project_ShouldInitializeWithEmptyTaskItems()
        {
            // Arrange
            var name = "Project B";
            var userId = Guid.NewGuid();

            // Act
            var project = new Project(name, userId);

            // Assert
            Assert.NotNull(project.TaskItem);
            Assert.Empty(project.TaskItem);  
        }
    }

}
