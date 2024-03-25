using System;

namespace ERP.Reports.Api.Models.Core
{

    public partial class ReportCustomizationView
    {
        [Obsolete("Only for ORM", true)]
        public ReportCustomizationView()
        {
        }

        public int OrganizationId { get; private set; }

        public string Id { get; private set; }

        public int CustomizationTypeId { get; private set; }

        public string CustomizationTypeCode { get; private set; }

        public string CustomizationTypeDescription { get; private set; }

        public int EntityId { get; private set; }

        public string EntityCode { get; private set; }

        public string EntityName { get; private set; }

        public string ReportId { get; private set; }

        public string FileName { get; private set; }

        public string StoreProcedure { get; private set; }

    }
}