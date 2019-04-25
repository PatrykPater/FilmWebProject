using Data.Infrastructure;

namespace Service
{
    public abstract class ServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;

        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Complete()
        {
            _unitOfWork.Complete();
        }
    }
}
