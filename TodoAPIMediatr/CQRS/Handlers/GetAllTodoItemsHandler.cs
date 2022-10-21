using MediatR;
using TodoAPIMediatr.CQRS.Queries;
using TodoAPIMediatr.Interfaces;
using TodoAPIMediatr.Model;
using TodoAPIMediatr.Converter;

namespace TodoAPIMediatr.CQRS.Handlers
{
    public class GetAllTodoItemsHandler : IRequestHandler<GetAllTodoItemsQuery, IEnumerable<TodoItem>>
    {
        private IRepository _repository { get; set; } = default!;
        public GetAllTodoItemsHandler(IRepository repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<TodoItem>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            var items = _repository.GetAllItems().Convert();
            return Task.FromResult(items.AsEnumerable());
        }
    }
}
