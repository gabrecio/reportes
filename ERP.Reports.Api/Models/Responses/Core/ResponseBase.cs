namespace ERP.Reports.Api.Models.Responses.Core
{
    public abstract class ResponseBase
    {
        public int StatusCode { get; }
        public string Message { get; }

        public ResponseBase(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}