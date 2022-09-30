using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Controllers;
using TodoAPI.Data;
using TodoAPI.Model;

namespace TodoAPI.Service
{
    public class TodoItemsService
    {
        private readonly TodoContext _context;
        private readonly ILogger _logger;

        // Dependency injection
        public TodoItemsService(TodoContext context, ILogger<TodoItemsController> logger)
        {
            _context = context;
            _logger = logger;
        }

    }
}
