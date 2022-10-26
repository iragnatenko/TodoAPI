using TodoAPIMediatr.Entity;
using TodoAPIMediatr.Model;

namespace TodoAPIMediatr.Converter
{
    public static class TodoItemConverter
    {
        public static TodoItem Convert(this TodoItemEntity from)
        {
            return new TodoItem()
            {
                Id = from.Id,
                Name = from.Name,
                IsComplete = from.IsComplete

            };
        }

        public static TodoItemEntity Convert(this TodoItem from)
        {
            return new TodoItemEntity()
            {
                Id = from.Id,
                Name = from.Name,
                IsComplete = from.IsComplete

            };
        }

        public static TodoItemEntity Convert(this AddTodoItem from)
        {
            return new TodoItemEntity()
            {
                Id = 0,
                Name = from.Name,
                IsComplete = from.IsComplete

            };
        }

        public static IEnumerable<TodoItemEntity> Convert(this IEnumerable<TodoItem> from)
        {
            if (from != null)
            {
                foreach (var item in from)
                {
                    yield return item.Convert();
                }
            }
        }
        public static IEnumerable<TodoItem> Convert(this IEnumerable<TodoItemEntity> from)
        {
            if (from != null)
            {
                foreach (var item in from)
                {
                    yield return item.Convert();
                }
            }
        }
    }
}
