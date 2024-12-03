using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;

namespace Application.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;
        public TaskItemService(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public async Task<TaskItem> CreateTaskItem(TaskItem taskItem)
        {
            TaskItem result = await _taskItemRepository.CreateTaskItem(taskItem);
            return result;
        }

        public TaskItem GetTaskItemById(Guid taskItemId)
        {
            TaskItem taskItem = _taskItemRepository.GetTaskItemById(taskItemId);
            return taskItem;
        }

        public bool DeleteTaskItem(Guid taskItemId)
        {
            TaskItem taskItem = GetTaskItemById(taskItemId);
            var result = _taskItemRepository.DeleteTaskItem(taskItem);

            return result;
        }

        public TaskItem UpdateTaskItem(TaskItem taskItem)
        {
            var result = _taskItemRepository.UpdateTaskItem(taskItem);

            return result;
        }
    }
}
