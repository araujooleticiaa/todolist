using Domain.Entities.Domain.Entities;

namespace Domain.Entities
{
    public class Project : BaseModel
    {
        public string Name { get; set; }

        public Guid UserId { get; set; }

        public User Owner { get; set; }

        public ICollection<TaskItem> TaskItem { get; set; } = new List<TaskItem>();
    }
}
