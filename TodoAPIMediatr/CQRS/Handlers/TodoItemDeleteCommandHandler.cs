using MediatR;
using NuGet.Protocol.Plugins;
using TodoAPIMediatr.CQRS.Commands;
using TodoAPIMediatr.Interfaces;

namespace TodoAPIMediatr.CQRS.Handlers
{
    public class TodoItemDeleteCommandHandler : IRequestHandler<TodoItemDeleteCommand, int>
    {
        private IRepository _repository { get; set; } = default;

        public TodoItemDeleteCommandHandler(IRepository repository)
        {
            _repository = repository;
        }
    
        public async Task<int> Handle(TodoItemDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _repository.DeleteItem(request.Id);
                return request.Id;
            }
            catch (Exception)
            {

                throw;
            }       
        }
    }
}
