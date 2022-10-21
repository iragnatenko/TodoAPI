using MediatR;
using TodoAPIMediatr.Model;

namespace TodoAPIMediatr.CQRS.Queries
{
    public record GetAllTodoItemsQuery : IRequest<IEnumerable<TodoItem>>; // this means that the request will return a list of TodoItems


}
