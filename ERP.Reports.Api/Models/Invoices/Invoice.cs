using ERP.Reports.Api.Models.Core;
using System;

namespace ERP.Reports.Api.Models.Invoices
{
    public class Invoice : TransactionBasic
    {
        public int CustomerId { get; private set; }

        [Obsolete("Only for ORM", true)]
        public Invoice() : base()
        {

        }
    }
}