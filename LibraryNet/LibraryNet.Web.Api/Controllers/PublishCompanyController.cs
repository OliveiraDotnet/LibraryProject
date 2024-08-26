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
    public class PublishCompanyController : ControllerBase
    {
        protected IPublisherServices Services { get; }
        protected ILogger<PublishCompanyController> Log { get; }
        public PublishCompanyController(IPublisherServices services, ILogger<PublishCompanyController> log)
        {
            Services = services;
            Log = log;
        }

        [HttpPost("Create")]
        [SwaggerOperation(Summary = "Create a PublishCompany", Description = "")]
        [SwaggerResponse(200, "PublishCompany created with Success", typeof(Core.Models.Publisher))]
        [SwaggerResponse(400, "Bad Request", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Internal Server Error", typeof(ErrorResponse))]
        public async Task<IActionResult> CreatePublishCompanyAsync(Core.Models.VO.Publisher PublishCompanyVO)
        {
            var publishCompany = PublishCompanyVO.Like<Core.Models.Publisher>();
            await Services.CreateAsync(publishCompany);
            return Ok();
        }
    }
}
