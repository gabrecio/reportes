using ERP.Reports.Api.Models.CreditMemos;
using ERP.Reports.Api.Models.DebitMemos;
using ERP.Reports.Api.Models.Invoices;
using System.Collections.Generic;
using System.Data;

namespace ERP.Reports.Api.Services.Core
{
    public static class ReportParamsHelper
    {
        public static Dictionary<string, object> GetReportParamsForInvoices(Invoice invoiceBasic)
        {
            var dt = new DataTable("Invoices");
            dt.Columns.Add("Id", typeof(int));
            dt.Rows.Add(invoiceBasic.Id);
            return new Dictionary<string, object> { { "OrganizationId", invoiceBasic.OrganizationId }, { "Invoices", dt } };
        }

        public static Dictionary<string, object> GetReportParamsForCreditMemos(CreditMemo creditMemo)
        {
            var dt = new DataTable("CreditMemos");
            dt.Columns.Add("Id", typeof(int));
            dt.Rows.Add(creditMemo.Id);
            return new Dictionary<string, object> { { "OrganizationId", creditMemo.OrganizationId }, { "CreditMemos", dt } };
        }

        public static Dictionary<string, object> GetReportParamsForDebitMemo(DebitMemo debitMemo)
           => new Dictionary<string, object> { { "OrganizationId", debitMemo.OrganizationId }, { "DebitMemoId", debitMemo.Id } };
    }
}