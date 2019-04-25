using Model.Models;

namespace Service
{
    public interface IAwardService
    {
        Award GetAwardById(int id);
        void Complete();
    }
}