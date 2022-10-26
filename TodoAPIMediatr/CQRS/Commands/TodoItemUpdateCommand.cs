using MediatR;
using TodoAPIMediatr.Model;

namespace TodoAPIMediatr.CQRS.Commands
{
    public class TodoItemUpdateCommand :IRequest<TodoItem>
    {
        public long Id { get; set; } = 0;
        public AddTodoItem todoItem { get; set; } = default;

    }
}
