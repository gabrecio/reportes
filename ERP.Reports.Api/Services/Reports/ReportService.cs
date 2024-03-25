using CSharpFunctionalExtensions;
using ERP.Reports.Api.Interfaces.Services;
using ERP.Reports.Api.Models.Requests;
using ERP.Reports.Api.Models.Responses.Core;
using ERP.Reports.Api.Services.Core;
using ERP.Reports.Api.Services.Reports.Queries;
using MediatR;
using System.Threading.Tasks;

namespace ERP.Reports.Api.Services.Reports
{
    public class ReportService : ServiceBase, IReportService
    {
        public ReportService(IMediator mediator)
            : base(mediator)
        {
        }
        public async Task<Result<FileModelResponse>> GetReport(GetReportRequest reportRequest)
            => await Mediator.Send(GetReportQuery.Create(reportRequest));
    }
}