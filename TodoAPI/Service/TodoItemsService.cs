using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Controllers;
using TodoAPI.Data;
using TodoAPI.Interfaces;
using TodoAPI.Model;

namespace TodoAPI.Service
{
    public class TodoItemsService : IRepository
    {
        private readonly TodoContext _context;
        private readonly ILogger<TodoItemsController> _logger;



        // Dependency injection
        public TodoItemsService(TodoContext context, ILogger<TodoItemsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<TodoItemDTO>> GetAllAsync()
        {
            return await _context.TodoItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        public async Task<TodoItemDTO> GetByIdAsync(long id)
        {
            var todoItem = await  _context.TodoItems.FindAsync(id);
            
            if (todoItem == null)
            {
                _logger.LogWarning(MyLogEvents.GetItemNotFound, "Get({Id}) NOT FOUND", id);
                throw new Exception($"Item ({id}) NOT FOUND");
            }

            return ItemToDTO(todoItem);
        }

        public async Task<TodoItemDTO> AddAsync(TodoItemDTO todoItemDTO)

        {
            var todoItem = new TodoItem()
            {
                IsComplete = todoItemDTO.IsComplete,
                Name = todoItemDTO.Name
            };

            _context.TodoItems.Add(todoItem);
            var res = await _context.SaveChangesAsync(); // efter man använder denna metod, sparas data i databasen

            todoItemDTO.Id = todoItem.Id; // todoItemDTO som vi skickar in som parameter vet inte vilken id fick objektet.
                                          // här talar vi om vilken id det är
            return todoItemDTO;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                _logger.LogWarning(MyLogEvents.GetItemNotFound, "Get ({Id}) NOT FOUND", id);
                return false;
                // throw new Exception($"Item ({id}) NOT FOUND");
            }

            _context.TodoItems.Remove(todoItem);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<TodoItemDTO> UpdateAsync(long id, TodoItemDTO todoItemDTO)
        {
            if (id != todoItemDTO.Id)
            {
                throw new Exception("Bad request");
            }

            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                throw new Exception($"Item ({id}) NOT FOUND");
            }

            todoItem.Name = todoItemDTO.Name;
            todoItem.IsComplete = todoItemDTO.IsComplete;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
            {
                throw new Exception($"Item ({id}) NOT FOUND");
            }

            return todoItemDTO;
        }
    
        private bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }

        private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
          new TodoItemDTO
          {
              Id = todoItem.Id,
              Name = todoItem.Name,
              IsComplete = todoItem.IsComplete
          };

    }
}
