using ERP.Reports.Api.Controllers.Core;
using ERP.Reports.Api.Interfaces.Services;
using ERP.Reports.Api.Models.Requests;
using ERP.Reports.Api.Models.Responses.Core;
using Swashbuckle.Swagger.Annotations;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ERP.Reports.Api.Controllers
{
    public class ReportsController : ApiControllerBase
    {
        private readonly IReportService reportService;

        public ReportsController(IReportService reportService)
        {
            this.reportService = reportService;
        }
        [HttpPost]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, type: typeof(FileModelResponse))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, type: typeof(ErrorResponse))]
        [SwaggerResponse(System.Net.HttpStatusCode.InternalServerError, type: typeof(ErrorResponse))]
        [SwaggerResponse(System.Net.HttpStatusCode.Unauthorized)]
        [ResponseType(typeof(FileModelResponse))]
        public async Task<IHttpActionResult> GetReport([FromBody] GetReportRequest reportRequest)
            => FromResult<FileModelResponse>(await reportService.GetReport(reportRequest));

    }
}
