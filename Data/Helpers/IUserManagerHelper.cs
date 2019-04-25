namespace Data.Helpers
{
    public interface IUserManagerHelper
    {
        bool PromoteToMod(string userId);
        bool IsModded(string userId);
    }
}