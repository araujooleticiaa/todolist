using Domain.Enums;

namespace Domain.Entities
{
    public class TaskItem : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public EStatus Status { get; set; }

        public Guid ProjectId { get; set; }

        // Relação com o projeto
        public Project Project { get; set; }

        // Histórico de modificações
        public ICollection<History> Histories { get; set; } = new List<History>();
    }
}
