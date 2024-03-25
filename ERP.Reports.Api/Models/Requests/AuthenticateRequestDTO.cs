using FluentValidation;

namespace ERP.Reports.Api.Models.Requests
{

    public class AuthenticateRequestDTO
    {
        public string User { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticateRequestDTOValidator : AbstractValidator<AuthenticateRequestDTO>
    {
        public AuthenticateRequestDTOValidator()
        {
            RuleFor(x => x.User)
                .NotEmpty();

            RuleFor(x => x.Password).NotEmpty();
        }
    }
}