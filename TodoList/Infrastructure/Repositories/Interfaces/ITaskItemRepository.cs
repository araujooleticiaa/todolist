using Domain.Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface ITaskItemRepository
    {
        TaskItem CreateTaskItem(TaskItem taskItem);
        TaskItem GetTaskItemById(Guid taskItemId);
        bool DeleteTaskItem(TaskItem taskItem);
        TaskItem UpdateTaskItem(TaskItem taskItem);
    }
}
