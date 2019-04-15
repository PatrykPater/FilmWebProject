namespace Web.Helpers
{
    public static class NameHelper
    {
        public static string GetFullUserName(string firstName, string lastName)
        {
            return firstName + " " + lastName;
        }
    }
}