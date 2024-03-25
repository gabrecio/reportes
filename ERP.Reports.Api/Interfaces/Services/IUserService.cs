using CSharpFunctionalExtensions;
using ERP.Reports.Api.Interfaces.Services.Core;
using ERP.Reports.Api.Models.Requests;
using ERP.Reports.Api.Models.Responses;
using System.Threading.Tasks;

namespace ERP.Reports.Api.Interfaces.Services
{
    public interface IUserService : IServiceBase
    {
        Task<Result<AuthenticateResponseDTO>> Authenticate(AuthenticateRequestDTO requestDto);
    }
}