using ERP.Reports.Api.Models.Core;
using System;

namespace ERP.Reports.Api.Models.CreditMemos
{
    public class CreditMemo : TransactionBasic
    {
        public int CustomerId { get; set; }

        [Obsolete("Only for ORM", true)]
        public CreditMemo() : base()
        {

        }
    }
}