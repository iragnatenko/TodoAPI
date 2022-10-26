using MediatR;
using TodoAPIMediatr.CQRS.Commands;
using TodoAPIMediatr.Entity;
using TodoAPIMediatr.Interfaces;
using TodoAPIMediatr.Converter;


namespace TodoAPIMediatr.CQRS.Handlers
{
    public class TodoAddCommandHandler : IRequestHandler<TodoItemAddCommand, TodoItemEntity>
    {
        private IRepository _repository {get; set; } = default!;

        public TodoAddCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoItemEntity> Handle(TodoItemAddCommand request, CancellationToken cancellationToken)
        {
            try
            {
                long newId = _repository.AddItem(request.todoItem.Convert());
                var retTodo = request.todoItem.Convert();
                retTodo.Id = newId;
                return retTodo;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
