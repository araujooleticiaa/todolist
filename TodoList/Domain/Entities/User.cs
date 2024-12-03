using Domain.Enums;

namespace Domain.Entities
{
    namespace Domain.Entities
    {
        public class User : BaseModel
        {
            public string Name { get; set; }
            public EFunction Role { get; set; }

            public ICollection<Project> Projects { get; set; } = new List<Project>();
        }
    }
}
