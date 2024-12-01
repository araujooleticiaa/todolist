using System.Threading.Tasks;

namespace TodoList.Models
{
    public class History : BaseModel
    { 
        public History() { }
        public History(Guid taskId, string modifiedField, string previousValue, string newValue, DateTime modifiedAt, Guid modifiedBy, Task taskModified)
        {
            TaskId = taskId;
            ModifiedField = modifiedField;
            PreviousValue = previousValue;
            NewValue = newValue;
            ModifiedAt = modifiedAt;
            ModifiedBy = modifiedBy;
            TaskModified = taskModified;
        }

        public Guid TaskId { get; set; }
        public string ModifiedField { get; set; } 
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid ModifiedBy { get; set; }

        public Task TaskModified { get; set; }
    }
}
