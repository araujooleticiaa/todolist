using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface ITaskItemService
    {
        Task<TaskItem> CreateTaskItem(TaskItem taskItem);
        TaskItem GetTaskItemById(Guid taskItemId);
        bool DeleteTaskItem(Guid taskItemId);
        TaskItem UpdateTaskItem(TaskItem product);
    }
}
