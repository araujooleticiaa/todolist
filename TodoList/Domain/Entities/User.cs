using Domain.Enums;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    namespace Domain.Entities
    {
        public class User : BaseModel
        {
            public string Name { get; set; }
            public EFunction Role { get; set; }

            [JsonIgnore]
            public ICollection<Project> Projects { get; set; } = new List<Project>();
        }
    }
}
