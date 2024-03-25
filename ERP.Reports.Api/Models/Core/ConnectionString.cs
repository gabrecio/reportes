namespace ERP.Reports.Api.Models.Core
{
    public class ConnectionString
    {
        public const string NAME = "DefaultERP";
        public string Connection { get; }

        public ConnectionString(string connection)
        {
            Connection = connection;
        }

    }
}