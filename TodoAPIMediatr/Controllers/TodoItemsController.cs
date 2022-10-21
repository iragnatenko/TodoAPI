using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TodoAPIMediatr.CQRS.Commands;
using TodoAPIMediatr.CQRS.Queries;
using TodoAPIMediatr.Entity;
using TodoAPIMediatr.Model;

namespace TodoAPIMediatr.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : Controller
    {

        private readonly IMediator _mediator;

        public TodoItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/todo>
        /// <summary>
        /// Get all todo's
        /// </summary>
        /// <returns>IEnumerable of Employee</returns>
        [HttpGet(Name = "todogetall")]
        [ProducesResponseType(typeof(List<TodoItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Get()
        {
            try
            {
                var clients = await _mediator.Send(new GetAllTodoItemsQuery());
                return Ok(clients);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        // GET api/todo/5
        /// <summary>
        /// Get todo by ID
        /// </summary>
        /// <param name="id">Id of tood</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "todogetbyid")]
        [ProducesResponseType(typeof(TodoItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            try
            {
                var item = await _mediator.Send(new GetTodoItemByIdQuery() { Id = id });
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }
        [HttpPost(Name = "todoadd")]
        [ProducesResponseType(typeof(TodoItem), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TodoItem>> Post(AddTodoItem todoItem)
        {
            try
            {
                var ret = await _mediator.Send(new TodoAddCommand() { todoItem  = todoItem });
                return CreatedAtRoute("todogetbyid", new { id = ret.Id }, ret);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }


    }
}
