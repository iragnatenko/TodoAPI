using MediatR;
using TodoAPIMediatr.Interfaces;
using TodoAPIMediatr.Model;

namespace TodoAPIMediatr.CQRS.Queries
{
    public class GetTodoItemByIdQuery : IRequest<TodoItem>
    {
        public long Id { get; set; }

    }
}
