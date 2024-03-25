using CSharpFunctionalExtensions;
using ERP.Reports.Api.Models.Requests;
using ERP.Reports.Api.Models.Responses.Core;
using System.Threading.Tasks;

namespace ERP.Reports.Api.Interfaces.Services
{
    public interface IReportService
    {
        Task<Result<FileModelResponse>> GetReport(GetReportRequest reportRequest);
    }
}