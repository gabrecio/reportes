using System;

namespace ERP.Reports.Api.Models.Core
{

    public partial class ReportAliasView
    {
        [Obsolete("Only for ORM", true)]
        public ReportAliasView()
        {
        }

        public int OrganizationId { get; private set; }

        public string ReportId { get; private set; }

        public int Sequence { get; private set; }

        public string Name { get; private set; }

    }
}