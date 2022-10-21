using MediatR;
using NuGet.Protocol.Plugins;
using TodoAPIMediatr.Converter;
using TodoAPIMediatr.CQRS.Queries;
using TodoAPIMediatr.Interfaces;
using TodoAPIMediatr.Model;

namespace TodoAPIMediatr.CQRS.Handlers
{
    public class GetTodoItemByIdHandler :IRequestHandler<GetTodoItemByIdQuery, TodoItem>
    {
        private IRepository _repository { get; set; } = default!;

        public GetTodoItemByIdHandler(IRepository repository)
        {
            _repository = repository;
        }


        public Task<TodoItem> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = _repository.GetById(request.Id);
            return Task.FromResult(item.Convert());
        }
    }
}
