namespace ERP.Reports.Api.Models.Core
{
    public class TransactionBasic
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int OrganizationId { get; set; }
        public int TransactionTypeId { get; set; }

        public TransactionBasic()
        {

        }

    }
}