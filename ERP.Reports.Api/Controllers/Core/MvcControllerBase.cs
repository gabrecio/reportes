using CSharpFunctionalExtensions;
using ERP.Reports.Api.Models.Responses.Core;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ERP.Reports.Api.Controllers.Core
{
    public abstract class MvcControllerBase : Controller
    {
        public ActionResult ProcessFile(Result<FileModelResponse> result)
        {
            if (result.IsFailure)
                return Json(ErrorResponse.Create((int)HttpStatusCode.BadRequest, result.Error));
            var file = result.Value;
            return File(file.File.Bytes, MimeMapping.GetMimeMapping(file.File.FileName), file.File.FileName);
        }
    }
}