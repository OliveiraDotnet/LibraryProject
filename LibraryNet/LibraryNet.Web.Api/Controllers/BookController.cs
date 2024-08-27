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

        [HttpGet("GetAll")]
        [SwaggerOperation(Summary = "Get all books", Description = "")]
        [SwaggerResponse(200, "Success", typeof(List<Book>))]
        [SwaggerResponse(400, "Bad Request", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Internal Server Error", typeof(ErrorResponse))]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await Services.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetByAuthor/{authorId}")]
        [SwaggerOperation(Summary = "Get all books by Author Id", Description = "")]
        [SwaggerResponse(200, "Success", typeof(List<Book>))]
        [SwaggerResponse(400, "Bad Request", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Internal Server Error", typeof(ErrorResponse))]
        public async Task<IActionResult> GetByAuthorAsync(string authorId)
        {
            var result = await Services.GetByAuthorAsync(authorId);
            return Ok(result);
        }

        [HttpGet("GetByLiteraryGenre/{literaryGenre}")]
        [SwaggerOperation(Summary = "Get all books by literaryGenre", Description = "")]
        [SwaggerResponse(200, "Success", typeof(List<Book>))]
        [SwaggerResponse(400, "Bad Request", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Internal Server Error", typeof(ErrorResponse))]
        public async Task<IActionResult> GetByLiteraryGenreAsync(int literaryGenre)
        {
            var result = await Services.GetByLiteraryGenreAsync(literaryGenre);
            return Ok(result);
        }

        [HttpGet("GetByPublisher/{publisherId}")]
        [SwaggerOperation(Summary = "Get all books by publisher Id", Description = "")]
        [SwaggerResponse(200, "Success", typeof(List<Book>))]
        [SwaggerResponse(400, "Bad Request", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Internal Server Error", typeof(ErrorResponse))]
        public async Task<IActionResult> GetByPublisherAsync(string publisherId)
        {
            var result = await Services.GetByPublisherAsync(publisherId);
            return Ok(result);
        }

        [HttpPost("Create")]
        [SwaggerOperation(Summary = "Create a book", Description = "")]
        [SwaggerResponse(200, "Book created with Success", typeof(string))]
        [SwaggerResponse(400, "Bad Request", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Internal Server Error", typeof(ErrorResponse))]
        public async Task<IActionResult> CreateAsync(BookVO bookVO)
        {
            var book = bookVO.Like<Book>();
            await Services.CreateAsync(book);
            return Ok(book.Name);
        }

        [HttpPut("Update")]
        [SwaggerOperation(Summary = "Update a book", Description = "")]
        [SwaggerResponse(200, "Book updated with Success", typeof(string))]
        [SwaggerResponse(400, "Bad Request", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Internal Server Error", typeof(ErrorResponse))]
        public async Task<IActionResult> UpdateAsync(BookVO bookVO)
        {
            var book = bookVO.Like<Book>();
            await Services.UpdateAsync(book);
            return Ok(book.Name);
        }

        [HttpDelete("Delete/{bookId}")]
        [SwaggerOperation(Summary = "Delete a book", Description = "")]
        [SwaggerResponse(200, "Deleted with success", typeof(string))]
        [SwaggerResponse(400, "Bad Request", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Internal Server Error", typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteAsync(string bookId)
        {
            await Services.DeleteAsync(bookId);
            return Ok(bookId);
        }
    }
}
