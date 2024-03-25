using System;

namespace ERP.Reports.Api.Models.Core
{

    public partial class ReportEntityPrinterView
    {
        [Obsolete("Only for ORM", true)]
        public ReportEntityPrinterView()
        {
        }

        public int Id { get; private set; }
        public int OrganizationId { get; private set; }
        public string ReportId { get; private set; }
        public int EntityId { get; private set; }
        public string EntityCode { get; private set; }
        public string EntityName { get; private set; }
        public int PrinterId { get; private set; }
        public string PrinterName { get; private set; }
        public string PrinterDescription { get; private set; }
        public int QtyCopies { get; private set; }
        public string ReportFileName { get; private set; }
        public string ReportFriendlyName { get; private set; }
        public string EmailTo { get; private set; }
        public int ReportEntityPrinterTypeId { get; private set; }
        public string ReportPrinterTypeCode { get; private set; }
        public string ReportPrinterTypeDescription { get; private set; }
        public int? ReportEntityPrinterType2Id { get; private set; }
        public string ReportPrinterType2Code { get; private set; }
        public string ReportPrinterType2Description { get; private set; }
        public int? Entity2Id { get; private set; }
        public string Entity2Code { get; private set; }
        public string Entity2Name { get; protected set; }
        public int? ReportEntityPrinterType3Id { get; private set; }
        public string ReportPrinterType3Code { get; private set; }
        public string ReportPrinterType3Description { get; private set; }
        public int? Entity3Id { get; private set; }
        public string Entity3Code { get; private set; }
        public string Entity3Name { get; private set; }
    }
}