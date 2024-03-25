using CSharpFunctionalExtensions;
using ERP.Reports.Api.Models.Core;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ERP.Reports.Api.Interfaces.Repository
{
    public interface IReportRepository : IBaseRepository
    {
        Task<Maybe<ReportView>> GetReport(int organizationId, string reportId);
        Task<DataSet> GetReportData(ReportView report, Dictionary<string, object> parameters);
    }
}