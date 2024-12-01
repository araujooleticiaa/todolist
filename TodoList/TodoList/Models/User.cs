using TodoList.Enums;

namespace TodoList.Models
{
    public class User : BaseModel
    {
        public User() { }
        public User(string name, EFunction functions)
        {
            Name = name;
            Functions = functions;
            Projects = new List<Project>();
        }

        public string Name { get; set; }
        public EFunction Functions { get; set; }

        public List<Project> Projects { get; set; }
    }
}
