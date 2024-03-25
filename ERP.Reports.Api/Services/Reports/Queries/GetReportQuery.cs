using CSharpFunctionalExtensions;
using ERP.Reports.Api.Interfaces.Repository;
using ERP.Reports.Api.Models.Requests;
using ERP.Reports.Api.Models.Responses.Core;
using ERP.Reports.Api.Services.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Reports.Api.Services.Reports.Queries
{
    public class GetReportQuery : IRequest<Result<FileModelResponse>>
    {
        public GetReportRequest ReportRequest { get; }

        private GetReportQuery(GetReportRequest reportRequest)
        {
            ReportRequest = reportRequest;
        }

        public static GetReportQuery Create(GetReportRequest reportRequest)
            => new GetReportQuery(reportRequest);
    }

    public class GetReportQueryHandler : ReportHandlerBase, IRequestHandler<GetReportQuery, Result<FileModelResponse>>
    {
        public GetReportQueryHandler(IReportRepository reportRepository)
            : base(reportRepository)
        {
        }

        public async Task<Result<FileModelResponse>> Handle(GetReportQuery request, CancellationToken cancellationToken)
        {
            var file = await this.GetReportDTO(request.ReportRequest);
            return file.Map(f => FileModelResponse.Create(f));
        }
    }
}