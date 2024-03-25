using System;
using System.Collections.Generic;

namespace ERP.Reports.Api.Models.Core
{

    public partial class ReportView
    {
        [Obsolete("Only for ORM", true)]
        public ReportView()
        {
            ReportAliases = new List<ReportAliasView>();
            ReportCustomizations = new List<ReportCustomizationView>();
            ReportEntityPrinters = new List<ReportEntityPrinterView>();
        }

        internal ReportView Initialize(IEnumerable<ReportCustomizationView> customizationViews, IEnumerable<ReportAliasView> aliasViews, IEnumerable<ReportEntityPrinterView> reportEntityPrinters)
        {
            ReportCustomizations = customizationViews;
            ReportAliases = aliasViews;
            ReportEntityPrinters = reportEntityPrinters;
            return this;
        }


        public int OrganizationId { get; private set; }

        public string Id { get; private set; }

        public string FileName { get; private set; }

        public string FriendlyName { get; private set; }

        public string StoreProcedure { get; private set; }

        public int ReportGroupId { get; private set; }

        public string ReportGroupDescription { get; private set; }

        public int? PrinterId { get; private set; }

        public string PrinterName { get; private set; }

        public string PrinterDescription { get; private set; }

        public int QtyCopies { get; private set; }

        public bool IsSystem { get; private set; }

        public string MessageOfTheDay { get; private set; }

        public bool EmailAttached { get; private set; }



        public IEnumerable<ReportCustomizationView> ReportCustomizations { get; private set; }

        public IEnumerable<ReportAliasView> ReportAliases { get; private set; }
        public IEnumerable<ReportEntityPrinterView> ReportEntityPrinters { get; private set; }
    }
}