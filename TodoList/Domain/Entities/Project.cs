using Domain.Entities.Domain.Entities;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Project : BaseModel
    {
        public Project() { }
        public Project(string name, Guid userId)
        {
            Name = name;
            UserId = userId;
        }

        public string Name { get; set; }

        public Guid UserId { get; set; }

        public User Owner { get; set; }

        [JsonIgnore]
        public ICollection<TaskItem> TaskItem { get; set; } = new List<TaskItem>();
    }
}
