using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TodoAPIMediatr.CQRS.Commands;
using TodoAPIMediatr.CQRS.Queries;
using TodoAPIMediatr.Entity;
using TodoAPIMediatr.Model;

namespace TodoAPIMediatr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly IMediator _mediator;

        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/todo>
        /// <summary>
        /// Get the base64 string
        /// </summary>
        /// <returns>Sring</returns>
        [HttpGet(Name = "tobase64")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<ActionResult<string>> GetFile()
        {

            try
            {
                var result = await _mediator.Send(new GetBase64StringQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }

        }

        [HttpPost(Name = "topdf")]
        [ProducesResponseType(typeof(DataClsEntity), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<DataClsEntity>> SendToPdf(DataCls data)
        {
            try
            {

                var result = await _mediator.Send(new AddPdfCommand() { data = data });

                return result;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

                return BadRequest(new DataClsEntity());

            }
        }

    }
}
