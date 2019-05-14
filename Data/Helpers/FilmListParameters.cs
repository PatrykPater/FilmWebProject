namespace Data.Helpers
{
    public class FilmListParameters
    {
        public string QuerySearch { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int MaxPageNumber { get; set; }
        public int CurrentPage { get; set; } = 1;


        //public OrderByEnum OrderBy { get; set; } = OrderByEnum.Title;

    }

    //public enum OrderByEnum
    //{
    //    Title
    //}
}
