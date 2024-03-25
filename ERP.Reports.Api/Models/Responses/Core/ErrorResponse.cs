using FluentValidation.Results;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ERP.Reports.Api.Models.Responses.Core
{
    public class ErrorResponse : ResponseBase
    {
        public IReadOnlyList<ErrorDetail> Errors { get; }

        private ErrorResponse(int statusCode, string message, IEnumerable<ErrorDetail> errors)
            : base(statusCode, message) => Errors = new List<ErrorDetail>(errors);

        public static ErrorResponse Create(int statusCode, string message, IEnumerable<ErrorDetail> errors) => new ErrorResponse(statusCode, message, errors);
        public static ErrorResponse Create(int statusCode, string message) => new ErrorResponse(statusCode, message, new List<ErrorDetail>());


        public override string ToString() => JsonConvert.SerializeObject(this);

        public static ErrorResponse Create(int statusCode, List<ValidationFailure> errors)
        {
            return ErrorResponse.Create(statusCode, "Error", errors.Select(e => ErrorDetail.Create(e.ErrorMessage)));
        }
    }
}