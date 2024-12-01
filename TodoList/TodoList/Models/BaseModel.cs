namespace TodoList.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
