using CSharpFunctionalExtensions;
using ERP.Reports.Api.Models.Core;
using ERP.Reports.Api.Models.Responses;
using ERP.Reports.Api.Models.Users;
using ERP.Reports.Api.Services.OAuths;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Reports.Api.Services.Users.Queries
{
    public class AuthenticateQuery : IRequest<Result<AuthenticateResponseDTO>>
    {
        public UserCredential User { get; }
        public UserPassword Password { get; }

        private AuthenticateQuery(UserCredential user, UserPassword password)
        {
            User = user;
            Password = password;

        }

        public static IResult<AuthenticateQuery> Create(string email, string password)
        {
            Result<UserCredential> userEmail = UserCredential.Create(email);
            Result<UserPassword> userPassword = UserPassword.Create(password);

            Result result = Result.Combine(userEmail, userPassword);
            if (result.IsFailure)
                return Result.Failure<AuthenticateQuery>(result.Error);

            return Result.Success(new AuthenticateQuery(userEmail.Value, userPassword.Value));
        }
    }

    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateQuery, Result<AuthenticateResponseDTO>>
    {
        private readonly IOauthServerApiClient oauthServerApiClient;
        private readonly OauthServerConfig oauthServerConfig;
        public AuthenticateCommandHandler(IOauthServerApiClient oauthServerApiClient, OauthServerConfig oauthServerConfig)
        {
            this.oauthServerApiClient = oauthServerApiClient;
            this.oauthServerConfig = oauthServerConfig;
        }
        public async Task<Result<AuthenticateResponseDTO>> Handle(AuthenticateQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await oauthServerApiClient.TokenAsync(new CredentialsValidatorRequest
                {
                    Password = request.Password.Password,
                    UserCredential = request.User.User,
                    Service = oauthServerConfig.Service
                });
                if (result is null || string.IsNullOrEmpty(result.Token))
                    return Result.Failure<AuthenticateResponseDTO>("Incorrect User Or Password.");
                return Result.Success(AuthenticateResponseDTO.Create(result.Token));
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode == 401)
                    return Result.Failure<AuthenticateResponseDTO>("Icorrect User Or Password.");
                throw;
            }
        }
    }


}