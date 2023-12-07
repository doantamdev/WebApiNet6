namespace MyWebAppApi6.Models
{
    public class PagniatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public PagniatedList(List<T> items, int count, int pageIndex,
            int pageSize)
        {
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count/ (double)pageSize);
            AddRange(items);
        }

        public static PagniatedList<T> Create(IQueryable<T> source,int pageIndex,
            int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .ToList();

            return new PagniatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
