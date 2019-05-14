namespace Data.Helpers
{
    public class FilmListParameters
    {
        public string QuerySearch { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        //public OrderByEnum OrderBy { get; set; } = OrderByEnum.Title;
        public int MaxPageNumber { get; set; }
    }

    //public enum OrderByEnum
    //{
    //    Title
    //}
}
