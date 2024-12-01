using TodoList.Enums;

namespace TodoList.Models
{
    public class Task : BaseModel
    {
        public Task() { }
        public Task(string title, string description, DateTime dateEnd, EStatus status, Guid projectId)
        {
            Title = title;
            Description = description;
            DateEnd = dateEnd;
            Status = status;
            ProjectId = projectId;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateEnd { get; set; }
        public EStatus Status { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public List<History> Histories { get; set; }
    }
}
