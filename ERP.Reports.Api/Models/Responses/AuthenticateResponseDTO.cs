namespace ERP.Reports.Api.Models.Responses
{
    public class AuthenticateResponseDTO
    {
        public string Token { get; }
        private AuthenticateResponseDTO(string token) => Token = token;
        public static AuthenticateResponseDTO Create(string token) => new AuthenticateResponseDTO(token);
    }
}