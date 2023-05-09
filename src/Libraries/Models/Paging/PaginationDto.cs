namespace Models.Paging
{
    public class PaginationDto
    {
        public int PageSize { get; set; } = 10;

        public int PageNumber { get; set; } = 1;

        public string Search { get; set; } = "";
    }

    public class PaginationSearchDto
    {
        public int PageSize { get; set; } = 10;

        public int PageNumber { get; set; } = 1;

        public string Keyword { get; set; } = "";
    }
    public class PaginationReponseDto<T> where T : class
    {

        public T Data { get; set; }
        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int TotalPage { get; set; }

        public int TotalItem { get; set; }
    }

}