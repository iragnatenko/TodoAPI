using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlazorAppTodoAPI.Models;
using TodoAPIMediatr.Helpers;

namespace BlazorAppTodoAPI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DatabaseContext _context;

        public IndexModel(DatabaseContext context)
        {
            _context = context;
        }

        public IList<TodoItem> TodoItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
 /*           if (_context.TodoItem != null)
            {
                TodoItem = await _context.TodoItem.ToListAsync();
            }
 */
        }
    }
}
