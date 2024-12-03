using Domain.Enums;

namespace Application.DTO
{
    public class CreateTaskItemRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public EStatus Status { get; set; }
        public EProperty Properties { get; set; }
        public string? Comments { get; set; }
        public Guid ProjectId { get; set; }
	}
}
