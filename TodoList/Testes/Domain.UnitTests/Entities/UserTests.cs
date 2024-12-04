using Domain.Entities;
using Domain.Enums;

namespace Domain.UnitTests.Entities
{
    public class UserTests
    {
        [Fact]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var name = "John Doe";
            var role = EFunction.Manager;

            // Act
            var user = new User
            {
                Name = name,
                Role = role
            };

            // Assert
            Assert.NotNull(user);
            Assert.Equal(name, user.Name);
            Assert.Equal(role, user.Role); 
            Assert.NotEqual(Guid.Empty, user.Id); 
            Assert.NotNull(user.Projects);  
            Assert.Empty(user.Projects); 
        }

        [Fact]
        public void User_ShouldInitializeWithEmptyProjects()
        {
            // Arrange
            var name = "Jane Doe";
            var role = EFunction.Officer; 

            // Act
            var user = new User
            {
                Name = name,
                Role = role
            };

            // Assert
            Assert.NotNull(user.Projects);
            Assert.Empty(user.Projects);
        }
    }

}
