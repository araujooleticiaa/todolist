using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IUsersService
    {
        Task<List<Project>> GetProjects(Guid UserId);
    }
}
