using ERP.Reports.Api.Models.Core;
using System.Collections.Generic;

namespace ERP.Reports.Api.Models.Responses.Core
{
    public class FileModel
    {

        public int TransactionId { get; }
        public int TransactionTypeId { get; }
        public int TransactionOrganizationId { get; }
        public string TransactionNumber { get; }
        public string FileName { get; }
        public int WeightForCustomer { get; }
        public byte[] Bytes { get; }
        public bool EmailAttached { get; }
        public int? PrintId { get; }
        public string PrintName { get; }

        public IEnumerable<ReportEntityPrinterView> ReportEntityPrinters { get; }

        private FileModel(TransactionBasic transactionBasic, string fileName, int weightForCustomer, byte[] bytes, bool emailAttached, int? printId, string printName, IEnumerable<ReportEntityPrinterView> reportEntityPrinters)

        {
            FileName = fileName;
            TransactionId = transactionBasic.Id;
            TransactionTypeId = transactionBasic.TransactionTypeId;
            TransactionOrganizationId = transactionBasic.OrganizationId;
            TransactionNumber = transactionBasic.Number;
            WeightForCustomer = weightForCustomer;
            Bytes = bytes;
            ReportEntityPrinters = reportEntityPrinters;
            EmailAttached = emailAttached;
            PrintId = printId;
            PrintName = printName;
        }
        public static FileModel Create(TransactionBasic transactionBasic, string fileName, int weightForCustomer, byte[] bytes, bool emailAttached, int? printId, string printName, IEnumerable<ReportEntityPrinterView> reportEntityPrinters)
            => new FileModel(transactionBasic, fileName, weightForCustomer, bytes, emailAttached, printId, printName, reportEntityPrinters);
    }
}