﻿using LibraryNet.Core.Interfaces.Services;
using LibraryNet.Core.Models;
using LibraryNet.Core.Models.VO;
using LibraryNet.Utils;
using LibraryNet.Utils.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryNet.Web.Api.Controllers
{
    [SwaggerTag("Manages processes related to Authors")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        protected IAuthorServices Services { get; }
        protected ILogger<AuthorController> Log { get; }
        public AuthorController(IAuthorServices services, ILogger<AuthorController> log)
        {
            Services = services;
            Log = log;
        }
        [HttpGet("GetAll")]
        [SwaggerOperation(Summary = "Get all Authors", Description = "")]
        [SwaggerResponse(200, "Success", typeof(List<Author>))]
        [SwaggerResponse(400, "Bad Request", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Internal Server Error", typeof(ErrorResponse))]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await Services.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("Create")]
        [SwaggerOperation(Summary = "Create a Author", Description = "")]
        [SwaggerResponse(200, "Author created with Success", typeof(string))]
        [SwaggerResponse(400, "Bad Request", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Internal Server Error", typeof(ErrorResponse))]
        public async Task<IActionResult> CreateAuthorAsync(AuthorVO AuthorVO)
        {
            var author = AuthorVO.Like<Author>();
            await Services.CreateAsync(author);
            return Ok(author.Name);
        }
    }
}
