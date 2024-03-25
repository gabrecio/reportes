using MediatR;

namespace ERP.Reports.Api.Interfaces.Services.Core
{
    public interface IServiceBase
    {
        IMediator Mediator { get; }
    }
}