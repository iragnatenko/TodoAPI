namespace TodoAPI.Model
{
    public class TodoItemAddDTO
    {
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }
    }
}
