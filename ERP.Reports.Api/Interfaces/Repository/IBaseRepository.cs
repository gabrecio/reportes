namespace ERP.Reports.Api.Interfaces.Repository
{
    public interface IBaseRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}