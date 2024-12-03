using Application.Services.Interfaces;
using Infrastructure.Data;

namespace Application.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly DataContext _context;

        public TaskItemService(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
