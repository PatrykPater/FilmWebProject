namespace Web.Helpers
{
    public static class DtoFactoryHelper
    {
        public static string GetFullUserName(string firstName, string lastName)
        {
            return firstName + " " + lastName;
        }
    }
}