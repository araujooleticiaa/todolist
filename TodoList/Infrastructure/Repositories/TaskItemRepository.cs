using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly DataContext _context;

        public TaskItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TaskItem> CreateTaskItem(TaskItem taskItem)
        {
            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();
            return taskItem;
        }

        public TaskItem GetTaskItemById(Guid taskItemId)
        {
            var taskItem = _context.TaskItems.AsNoTracking().FirstOrDefault(p => p.Id == taskItemId);
            return taskItem;
        }

        public bool DeleteTaskItem(TaskItem taskItem)
        {
            _context.TaskItems.Remove(taskItem);
            var result = _context.SaveChanges();
            return result == 1;
        }
        public TaskItem UpdateTaskItem(TaskItem taskItem)
        {
            var taskItemOld = _context.TaskItems.First(p => p.Id == taskItem.Id);

            var historyEntries = new List<History>();

            if (taskItemOld.Title != taskItem.Title)
            {
                historyEntries.Add(new History
                {
                    TaskId = taskItem.Id,
                    ModifiedField = nameof(taskItem.Title),
                    PreviousValue = taskItemOld.Title,
                    NewValue = taskItem.Title,
                    ModifiedAt = DateTime.UtcNow,
                    ModifiedBy = taskItem.Project.UserId
                });
                taskItemOld.Title = taskItem.Title;
            }

            if (taskItemOld.Description != taskItem.Description)
            {
                historyEntries.Add(new History
                {
                    TaskId = taskItem.Id,
                    ModifiedField = nameof(taskItem.Description),
                    PreviousValue = taskItemOld.Description,
                    NewValue = taskItem.Description,
                    ModifiedAt = DateTime.UtcNow,
                    ModifiedBy = taskItem.Project.UserId
                });
                taskItemOld.Description = taskItem.Description;
            }

            if (taskItemOld.DueDate != taskItem.DueDate)
            {
                historyEntries.Add(new History
                {
                    TaskId = taskItem.Id,
                    ModifiedField = nameof(taskItem.DueDate),
                    PreviousValue = taskItemOld.DueDate.ToString("o"),
                    NewValue = taskItem.DueDate.ToString("o"),
                    ModifiedAt = DateTime.UtcNow,
                    ModifiedBy = taskItem.Project.UserId
                });
                taskItemOld.DueDate = taskItem.DueDate;
            }

            if (taskItemOld.Status != taskItem.Status)
            {
                historyEntries.Add(new History
                {
                    TaskId = taskItem.Id,
                    ModifiedField = nameof(taskItem.Status),
                    PreviousValue = taskItemOld.Status.ToString(),
                    NewValue = taskItem.Status.ToString(),
                    ModifiedAt = DateTime.UtcNow,
                    ModifiedBy = taskItem.Project.UserId
                });
                taskItemOld.Status = taskItem.Status;
            }

            _context.TaskItems.Update(taskItemOld);

            if (historyEntries.Any())
            {
                _context.Histories.AddRange(historyEntries);
            }

            _context.SaveChanges();

            return taskItemOld;
        }
    }
}
