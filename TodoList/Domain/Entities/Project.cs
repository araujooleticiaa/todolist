using Domain.Entities.Domain.Entities;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Project 
    {
		public Project(string name, Guid userId) 
		{
			Name = name;
			UserId = userId; 
		}

		public Guid ID { get; set; }  = Guid.NewGuid();

        public string Name { get; set; }

        public Guid UserId { get; set; }

        public User Owner { get; set; }

        [JsonIgnore]
        public ICollection<TaskItem> TaskItem { get; set; } = new List<TaskItem>();
    }
}
