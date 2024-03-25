using ERP.Reports.Api.Interfaces.Repository;

namespace ERP.Reports.Api.Repository
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public IUnitOfWork UnitOfWork => _unitOfWork;
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}