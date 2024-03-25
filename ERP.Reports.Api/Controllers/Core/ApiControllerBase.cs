using CSharpFunctionalExtensions;
using ERP.Reports.Api.Models.Responses.Core;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Reports.Api.Controllers.Core
{
    [Authorize]
    public abstract class ApiControllerBase : ApiController
    {
        protected IHttpActionResult Error(ErrorResponse e) => new MyBadRequest(e);

        protected new IHttpActionResult Ok<TResult>(TResult result) => base.Ok(result);
        protected IHttpActionResult FromResult(Result result) => result.IsSuccess ? Ok() : Error(ErrorResponse.Create((int)HttpStatusCode.BadRequest, result.Error));
        protected IHttpActionResult FromResult<TResult>(Result<TResult> result)
        {
            if (result.IsSuccess)
                return Ok(result.Value);
            ModelState.AddModelError("Errors", result.Error);
            if (result.Error == "User Or Password Icorrect")
                return Unauthorized();
            return Error(ErrorResponse.Create((int)HttpStatusCode.BadRequest, result.Error));
        }
    }

    public class MyBadRequest : IHttpActionResult
    {
        private readonly ErrorResponse errorResponse;

        public MyBadRequest(ErrorResponse errorResponse)
        {
            this.errorResponse = errorResponse;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            response.Content = new StringContent(errorResponse.ToString(), Encoding.UTF8, "application/json");
            return Task.FromResult(response);
        }
    }
}
