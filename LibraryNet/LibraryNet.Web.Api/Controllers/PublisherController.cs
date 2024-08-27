using LibraryNet.Core.Interfaces.Services;
using LibraryNet.Core.Models;
using LibraryNet.Core.Models.VO;
using LibraryNet.Utils;
using LibraryNet.Utils.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryNet.Web.Api.Controllers
{
    [SwaggerTag("Manages processes related to Publishing Companies")]
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        protected IPublisherServices Services { get; }
        protected ILogger<PublisherController> Log { get; }
        public PublisherController(IPublisherServices services, ILogger<PublisherController> log)
        {
            Services = services;
            Log = log;
        }
        [HttpGet("GetAll")]
        [SwaggerOperation(Summary = "Get all Publishers", Description = "")]
        [SwaggerResponse(200, "Success", typeof(List<Publisher>))]
        [SwaggerResponse(400, "Bad Request", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Internal Server Error", typeof(ErrorResponse))]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await Services.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("Create")]
        [SwaggerOperation(Summary = "Create a PublishCompany", Description = "")]
        [SwaggerResponse(200, "PublishCompany created with Success", typeof(string))]
        [SwaggerResponse(400, "Bad Request", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Internal Server Error", typeof(ErrorResponse))]
        public async Task<IActionResult> CreatePublishCompanyAsync(PublisherVO PublishCompanyVO)
        {
            var publishCompany = PublishCompanyVO.Like<Publisher>();
            await Services.CreateAsync(publishCompany);
            return Ok(publishCompany.Name);
        }
    }
}
