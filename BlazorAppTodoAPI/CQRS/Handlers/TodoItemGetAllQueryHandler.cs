using BlazorAppTodoAPI.CQRS.Queries;
using BlazorAppTodoAPI.Interfaces;
using BlazorAppTodoAPI.Models;
using MediatR;

namespace BlazorAppTodoAPI.CQRS.Handlers
{
    public class TodoItemGetAllQueryHandler : IRequestHandler<TodoItemGetAllQuery, IEnumerable<TodoItem>>
    {
        private readonly ITokenService _tokenService;
        private readonly ITodoItemService _todoItemService;
        private readonly TodoItemServiceConfig _todoItemServiceConfig;
        private string Token { get; set; } = string.Empty;

        public TodoItemGetAllQueryHandler(ITokenService tokenService, ITodoItemService todoItemService, TodoItemServiceConfig todoItemServiceConfig)
        {
            _tokenService = tokenService;
            _todoItemService = todoItemService;
            _todoItemServiceConfig = todoItemServiceConfig; 
        }

        public async Task<IEnumerable<TodoItem>> Handle(TodoItemGetAllQuery request, CancellationToken cancellationToken)
        {

            if (String.IsNullOrEmpty(Token))
            {
                TokenRequest tokenReq = new TokenRequest();
                tokenReq.Email = _todoItemServiceConfig.Email;
                tokenReq.Password = _todoItemServiceConfig.Password;

                Token = await _tokenService.GetTokenAsync(tokenReq);
            }
            var todos = await _todoItemService.GetAllAsync(Token);
            return todos.AsEnumerable();
        }

    }
}
