using MediatR;

namespace TodoAPIMediatr.CQRS.Commands
{
    public class TodoItemDeleteCommand : IRequest<int>
    {
        public int Id { get; set; } = 0;
    }
}
