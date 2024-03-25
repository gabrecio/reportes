namespace ERP.Reports.Api.Models.Core
{
    public class OauthJwtConfig
    {
        public const string OAUTHJWT_KEY = "OauthJwt.Key";
        public const string OAUTHJWT_ISSUER = "OauthJwt.Issuer";
        public const string OAUTHJWT_AUDIENCE = "OauthJwt.Audience";
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
    }
}