namespace TodoList.Models
{
    public class Project : BaseModel
    {
        public Project() { }
        public Project(string name, Guid userId, List<Task> tasks)
        {
            Name = name;
            UserId = userId;
            Tasks = tasks;
        }

        public string Name { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public List<Task> Tasks { get; set; }
    }
}
