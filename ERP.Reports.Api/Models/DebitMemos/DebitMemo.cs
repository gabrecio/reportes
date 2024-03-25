using ERP.Reports.Api.Models.Core;
using System;

namespace ERP.Reports.Api.Models.DebitMemos
{
    public class DebitMemo : TransactionBasic
    {
        [Obsolete("Only for ORM", true)]
        public DebitMemo() : base()
        {

        }
    }
}