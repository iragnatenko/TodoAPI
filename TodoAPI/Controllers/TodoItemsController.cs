using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Net.Mime;
using System.Security.Policy;
using System.Xml.Linq;
using TodoAPI.Data;
using TodoAPI.Interfaces;
using TodoAPI.Model;

namespace TodoAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly ILogger<TodoItemsController> _logger;
        private readonly IRepository _todoService;

        // Dependency injection
        public TodoItemsController(TodoContext context,
            ILogger<TodoItemsController> logger,
            IRepository todoService) // or ILoggerFactory logger
        {
            _context = context;
            _logger = logger;
            _todoService = todoService;
            // _logger = logger.CreateLogger("MyCategory");
            // ILogger<T> is equivalent to calling CreateLogger with the fully qualified type name of T.

        }
        // GET: api/TodoItems
        /// <summary>
        /// Returns a list of all TodoItems.
        /// </summary>
        [HttpGet(Name = "todoitemsall")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TodoItemDTO>))]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            try
            {
                _logger.LogInformation("Returned all the tasks from database");
                var res = await _todoService.GetAllAsync();
                return Ok(res);


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                _logger.LogError(ex.Message);
                //                return StatusCode(500, "Internal Server Error");
                throw;
            }
        }

        // GET: api/TodoItems/5
        /// <summary>
        /// Returns a specific TodoItem.
        /// </summary>
        /// <param name="id"> TodoItem id</param>
        /// <response code="201">Returns a specific item</response>
        /// <response code="404">If item id is not found</response>
        [HttpGet("{id}", Name = "todoitemgetbyid")]// routing mellan {id} och GetTodoItem(long id). Ska heta samma namn
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TodoItemDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        {
            try
            {
                _logger.LogInformation(MyLogEvents.GetItem, "Getting item {Id}", id);
                var result = await _todoService.GetByIdAsync(id);

                if (result == null)
                {
                    _logger.LogWarning(MyLogEvents.GetItemNotFound, "Get({Id}) NOT FOUND", id);
                    return NotFound();
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST: api/TodoItems
        /// <summary>
        /// Creates a new TodoItem.
        /// </summary>

        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost(Name = "todoitemadd")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(201)]// The [ProducesResponseType] attribute's Type property can be excluded in the ActionResult<T>, 
                                   // unlike IActionResult
                                   // [ProducesResponseType(200, Type = typeof(TodoItemDTO)] is simplified to [ProducesResponseType(200)].
                                   // The action's expected return type is instead inferred from the T in ActionResult<T>.
                                   // 
        [ProducesResponseType(400)]
        // [ProducesResponseType(StatusCodes.Status201Created]Type = typeof(TodoItemDTO))]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TodoItemDTO>> CreateTodoItem(TodoItemDTO todoItemDTO)
        {
            try
            {
                var added = await _todoService.AddAsync(todoItemDTO);
                return CreatedAtRoute("todoitemgetbyid", new { id = todoItemDTO.Id }, todoItemDTO); // här får man en länk i resultat, unlike Create()

                // if we didn't have service class, the code would look like this: 
                // _context.TodoItemsDTO.Add(todoItemDTO);
                // await _context.SaveChangesAsync();
                // return Ok(todoItemDTO);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");

            }
        }


        // PUT: api/TodoItems/5
        /// <summary>
        /// Updates a specific TodoItem.
        /// </summary>
        [HttpPut(Name = "todoitemupdate")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(TodoItemDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTodoItem(long id, TodoItemDTO todoItemDTO)
        {
            try
            {
                var todo = await _todoService.UpdateAsync(id, todoItemDTO);
                return Accepted(todo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }

            return NoContent();
        }
        // DELETE: api/TodoItems/5
        // Adding triple-slash comments to an action enhances the Swagger UI by adding the description to the section header.
        // Add a<summary> element above the Delete action:
        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        [HttpDelete("{id}", Name = "todoitemdelete")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(TodoItemDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            try
            {
                var todoItem = await _todoService.DeleteAsync(id);

                if (todoItem == false)
                {
                    return NotFound();
                }

                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
                        
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
