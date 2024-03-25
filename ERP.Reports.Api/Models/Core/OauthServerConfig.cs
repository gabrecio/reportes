namespace ERP.Reports.Api.Models.Core
{
    public class OauthServerConfig
    {
        public const string OAUTHSERVER_KEY = "OauthServerConfig.OauthServer";
        public const string SERVICE_KEY = "OauthServerConfig.Service";
        public string OauthServer { get; set; } = string.Empty;
        public string Service { get; set; } = string.Empty;
    }
}