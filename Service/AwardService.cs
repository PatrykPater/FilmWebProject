using Data.Infrastructure;
using Model.Models;

namespace Service
{
    public class AwardService : ServiceBase, IAwardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AwardService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Award GetAwardById(int id)
        {
            return _unitOfWork.Awards.GetById(id);
        }
    }
}
