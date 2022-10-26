using MediatR;
using NuGet.Protocol.Plugins;
using TodoAPIMediatr.Converter;
using TodoAPIMediatr.CQRS.Commands;
using TodoAPIMediatr.Interfaces;
using TodoAPIMediatr.Model;

namespace TodoAPIMediatr.CQRS.Handlers
{
    public class TodoItemUpdateCommandHandler : IRequestHandler<TodoItemUpdateCommand, TodoItem>
    {

        private IRepository _repository { get; set; } = default;
        public TodoItemUpdateCommandHandler(IRepository repository)
        {
            _repository = repository;
        }
    
        public async Task<TodoItem> Handle(TodoItemUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = request.todoItem.Convert();
            entity.Id = request.Id;
            var todo = _repository.UpdateItem(entity);
            return todo.Convert(); 
        }
    }
}
