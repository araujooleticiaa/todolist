namespace Domain.Entities
{
    public class History
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public string? ModifiedField { get; set; }
        public string? PreviousValue { get; set; }
        public string? NewValue { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid ModifiedBy { get; set; }

        public TaskItem? TaskItem { get; set; }

        public User? ModifiedUser { get; set; }
    }
}
