using System.Collections.Generic;

namespace ERP.Reports.Api.Models.Requests
{
    public class GetManyInvoicesRequest
    {
        public IEnumerable<int> InvoicesIds { get; set; }
        public GetManyInvoicesRequest()
        {
            InvoicesIds = new List<int>();
        }
    }
}