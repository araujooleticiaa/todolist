using Domain.Enums;
namespace Application.DTO
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public EFunction Role { get; set; }
    }
}
