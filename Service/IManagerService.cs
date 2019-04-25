namespace Service
{
    public interface IManagerService
    {
        bool PromoteToMod(string userId);
        bool IsModded(string userId);
    }
}