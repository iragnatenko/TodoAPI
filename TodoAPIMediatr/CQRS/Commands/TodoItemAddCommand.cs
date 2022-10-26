using MediatR;
using TodoAPIMediatr.Entity;
using TodoAPIMediatr.Model;

namespace TodoAPIMediatr.CQRS.Commands
{
    public class TodoItemAddCommand : IRequest<TodoItemEntity>
    {
        public AddTodoItem todoItem { get; set; } = default!; 
    }
}
