using LibraryNet.Core.Interfaces.Services;
using LibraryNet.Core.Models;
using LibraryNet.Core.Models.VO;
using LibraryNet.Utils;
using LibraryNet.Utils.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryNet.Web.Api.Controllers
{
    [SwaggerTag("Manages processes related to books")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        protected IBookServices Services { get; }
        protected ILogger<BookController> Log { get; }
        public BookController(IBookServices services, ILogger<BookController> log)
        {
            Services = services;
            Log = log;
        }

        [HttpPost("Create")]
        [SwaggerOperation(Summary = "Create a book", Description = "")]
        [SwaggerResponse(200, "Book created with Success", typeof(Book))]
        [SwaggerResponse(400, "Bad Request", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Internal Server Error", typeof(ErrorResponse))]
        public async Task<IActionResult> CreateBookAsync(BookVO bookVO)
        {
            var book = bookVO.Like<Book>();
            await Services.CreateAsync(book);
            return Ok();
        }
    }
}
