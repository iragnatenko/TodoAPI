using MediatR;
using TodoAPIMediatr.CQRS.Queries;
using TodoAPIMediatr.Interfaces;

namespace TodoAPIMediatr.CQRS.Handlers
{
    public class CheckTodoItemExistQueryHandler : IRequestHandler<CheckTodoItemExistQuery, bool>
    {
        private IRepository _repository;

        public CheckTodoItemExistQueryHandler(IRepository repository)
        {
            _repository = repository;
        }
    
        public Task<bool> Handle(CheckTodoItemExistQuery request, CancellationToken cancellationToken)
        {
            var item = _repository.CheckTodo(request.Id);
            return Task.FromResult(item);
        }
    }
}
