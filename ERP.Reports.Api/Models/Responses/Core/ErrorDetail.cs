using Newtonsoft.Json;

namespace ERP.Reports.Api.Models.Responses.Core
{
    public class ErrorDetail
    {
        public string Message { get; }
        private ErrorDetail(string message) => Message = message;

        public static ErrorDetail Create(string message) => new ErrorDetail(message);

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}