using LibraryNet.Utils;
using LibraryNet.Utils.Exceptions;
using LibraryNet.Utils.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ResourcesCore = LibraryNet.Core.Properties.Resources;

namespace LibraryNet.Web.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        protected ILogger<ErrorController> Log { get; }
        public ErrorController(ILogger<ErrorController> log)
        {
            Log = log;
        }

        [Route("/error")]
        public IActionResult Erro()
        {
            var contextoErro = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var errorPathRequest = contextoErro.Path;
            Log.LogError(contextoErro.Error, "Ocorreu um erro ao processar a requisição: {caminhoRequisicaoErro}", errorPathRequest);

            if (contextoErro.Error is ExceptionBase erroBase)
            {
                return BadRequest(erroBase.ParaErroResposta());
            }

            return StatusCode(HttpStatusCode.InternalServerError.EnumValue(), new ErrorResponse(errorCode: HttpStatusCode.InternalServerError.EnumValueToString(), message: ResourcesCore.GenericProcessError));
        }
    }
}