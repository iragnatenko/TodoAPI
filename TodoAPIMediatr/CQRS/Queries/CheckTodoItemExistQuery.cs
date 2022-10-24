using MediatR;

namespace TodoAPIMediatr.CQRS.Queries
{
    public class CheckTodoItemExistQuery : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
