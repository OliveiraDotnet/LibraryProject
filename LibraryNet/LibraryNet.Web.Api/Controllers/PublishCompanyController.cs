using LibraryNet.Core.Interfaces.Services;
using LibraryNet.Core.Models;
using LibraryNet.Core.Models.VO;
using LibraryNet.Utils;
using LibraryNet.Utils.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryNet.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishCompanyController : ControllerBase
    {
        protected IPublishCompanyServices Services { get; }
        protected ILogger<PublishCompanyController> Log { get; }
        public PublishCompanyController(IPublishCompanyServices services, ILogger<PublishCompanyController> log)
        {
            Services = services;
            Log = log;
        }

        [HttpPost("Create")]
        [SwaggerOperation(Summary = "Create a PublishCompany", Description = "")]
        [SwaggerResponse(200, "PublishCompany created with Success", typeof(PublishCompany))]
        [SwaggerResponse(400, "Bad Request", typeof(ErrorResponse))]
        [SwaggerResponse(500, "Internal Server Error", typeof(ErrorResponse))]
        public async Task<IActionResult> CreatePublishCompanyAsync(PublishCompanyVO PublishCompanyVO)
        {
            var publishCompany = PublishCompanyVO.Like<PublishCompany>();
            await Services.CreateAsync(publishCompany);
            return Ok();
        }
    }
}
