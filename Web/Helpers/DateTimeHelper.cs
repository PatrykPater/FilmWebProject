using System;

namespace Web.Helpers
{
    public static class DateTimeHelper
    {
        public static string GetDate(DateTime datetime)
        {
            return datetime.ToString("yyyy / M / dd");
        }
    }
}