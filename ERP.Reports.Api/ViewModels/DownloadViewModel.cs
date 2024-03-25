using System.Collections.Generic;

namespace ERP.Reports.Api.ViewModels
{
    public class DownloadViewModel
    {
        public string Json { get; set; } = "{\"ReportId\":\"AR.Invoice\",\"Parameters\":{\"OrganizationId\":5,\"Invoices\":[{\"Id\":1}]},\"CustomReportParameters\":null,\"Transaction\":{\"Id\":1,\"Number\":\"IINV012053077\",\"OrganizationId\":5,\"TransactionTypeId\":12000}}";
        public List<string> Errors { get; set; }
        public DownloadViewModel()
        {
            Errors = new List<string>();
        }
    }
}