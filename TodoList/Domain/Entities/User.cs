using Domain.Enums;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public EFunction Role { get; set; }

        [JsonIgnore]
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
