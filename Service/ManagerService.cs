using Data.Infrastructure;

namespace Service
{
    public class ManagerService : IManagerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManagerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool PromoteToMod(string userId)
        {
            return _unitOfWork.ManagerHelper.PromoteToMod(userId);
        }

        public bool IsModded(string userId)
        {
            return _unitOfWork.ManagerHelper.IsModded(userId);
        }
    }
}
