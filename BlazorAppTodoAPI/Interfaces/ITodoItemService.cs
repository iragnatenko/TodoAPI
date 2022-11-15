using BlazorAppTodoAPI.Models;
using TodoAPIMediatr.Entity;

namespace BlazorAppTodoAPI.Interfaces
{
    public interface ITodoItemService
    {
        public Task<IEnumerable<TodoItem>> GetAllAsync(string token);
        public Task<TodoItem> GetByIdAsync(string token, int id);
        public Task<TodoItem> AddAsync(string token, AddTodoItem todo);
        public Task<bool> DelAsync(string token, int id);
        public Task<TodoItem> UpdateAsync(string token, int id, AddTodoItem todo);

    }
}