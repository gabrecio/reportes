using ERP.Reports.Api.Models.Core;
using System.Collections.Generic;

namespace ERP.Reports.Api.Models.Requests
{
    public class GetReportRequest
    {
        public string ReportId { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public CustomReportParameter CustomReportParameters { get; set; }
        public TransactionBasic Transaction { get; set; }
    }
}