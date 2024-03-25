using ERP.Reports.Api.Controllers.Core;
using ERP.Reports.Api.Interfaces.Services;
using ERP.Reports.Api.Models.Requests;
using ERP.Reports.Api.Models.Responses;
using ERP.Reports.Api.Models.Responses.Core;
using Swashbuckle.Swagger.Annotations;
using System.Threading.Tasks;
using System.Web.Http;
//using System.Web.Http;
using System.Web.Http.Description;

namespace ERP.Reports.Api.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, type: typeof(AuthenticateResponseDTO))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, type: typeof(ErrorResponse))]
        [SwaggerResponse(System.Net.HttpStatusCode.InternalServerError, type: typeof(ErrorResponse))]
        [ResponseType(typeof(AuthenticateResponseDTO))]
        public async Task<IHttpActionResult> Authenticate([FromBody] AuthenticateRequestDTO dto) => FromResult<AuthenticateResponseDTO>(await userService.Authenticate(dto));
    }
}