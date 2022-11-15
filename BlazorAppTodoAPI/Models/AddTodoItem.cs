namespace BlazorAppTodoAPI.Models
{
    public class AddTodoItem
    {
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }
    }
}
