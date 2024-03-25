using ERP.Reports.Api.Interfaces.Services.Core;
using MediatR;

namespace ERP.Reports.Api.Services.Core
{
    public abstract class ServiceBase : IServiceBase
    {
        public IMediator Mediator { get; }
        public ServiceBase(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}