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
            var result = _unitOfWork.ManagerHelper.PromoteToMod(userId);

            return result;
        }
    }
}
