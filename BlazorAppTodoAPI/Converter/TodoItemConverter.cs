

using BlazorAppTodoAPI.Models;

namespace BlazorAppTodoAPI.Converter
{
    public static class TodoItemConverter
    {
        public static TodoItem Convert(this AddTodoItem from)
        {
            return new TodoItem()
            {
                Id = 0,
                Name = from.Name,
                IsComplete = from.IsComplete

            };
        }

        public static AddTodoItem Convert(this TodoItem from)
        {
            return new AddTodoItem()
            {
                Name = from.Name,
                IsComplete = from.IsComplete

            };
        }
    }
}
