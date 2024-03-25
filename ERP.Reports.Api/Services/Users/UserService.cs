using CSharpFunctionalExtensions;
using ERP.Reports.Api.Interfaces.Services;
using ERP.Reports.Api.Models.Requests;
using ERP.Reports.Api.Models.Responses;
using ERP.Reports.Api.Services.Core;
using ERP.Reports.Api.Services.Users.Queries;
using MediatR;
using System.Threading.Tasks;

namespace ERP.Reports.Api.Services.Users
{
    public class UserService : ServiceBase, IUserService
    {
        public UserService(IMediator mediator)
            : base(mediator)
        {

        }
        public async Task<Result<AuthenticateResponseDTO>> Authenticate(AuthenticateRequestDTO requestDto)
        {
            var query = AuthenticateQuery.Create(requestDto.User, requestDto.Password);
            if (query.IsFailure)
                return Result.Failure<AuthenticateResponseDTO>(query.Error);
            return await Mediator.Send(query.Value);
        }
    }
}