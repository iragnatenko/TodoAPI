using BlazorAppTodoAPI.Models;
using MediatR;

namespace BlazorAppTodoAPI.CQRS.Queries
{
    public class TodoItemGetAllQuery : IRequest<IEnumerable<TodoItem>>
    {
    }
}
