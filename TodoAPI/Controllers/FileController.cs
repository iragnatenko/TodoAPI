using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Mime;
using TodoAPI.Data;
using TodoAPI.Interfaces;
using TodoAPI.Model;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly Service.FileService _fileService;
        private readonly TodoContext _context;
        private readonly ILogger<FileController> _logger;

        public FileController(TodoContext context, Service.FileService fileService, ILogger<FileController> logger)
        {
            _context = context;
            _fileService = fileService; 
            _logger = logger;
        }

        [HttpGet(Name = "tobase64")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<ActionResult<string>> GetFile()
        {
            try
            {
                _logger.LogInformation("In the controller get method");

                string ret = await _fileService.PdfToStringAsync();
                return Ok(ret);


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //                return StatusCode(500, "Internal Server Error");
                throw;
            }
        }

        [HttpPost(Name = "topdf")]
//        [Consumes(MediaTypeNames.Application.Json)]
//        [Produces("application/pdf;base64")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]

        public async Task<string> SendToPdf([FromBody] DataCls data)
        {
            try
            {
                _logger.LogInformation("In the controller post method");
                var added = await _fileService.StringToPdfAsync(data.Base64);
                return "Ok";

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

                return  "Internal Server Error";

            }
        }
    }
}
