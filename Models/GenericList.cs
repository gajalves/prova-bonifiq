namespace ProvaPub.Models
{
    public class GenericList<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalCount { get; set; }
        public bool HasNext { get; set; }

        public GenericList(List<T> items, int totalCount, int page, int defaultPageSize)
        {
            Items = items;
            TotalCount = totalCount;
            HasNext = VerifyHasNext(totalCount, page, defaultPageSize);
        }

        private Boolean VerifyHasNext(int totalCount, int page, int defaultPageSize)
        {
            return (page * defaultPageSize) < totalCount;
        }
    }
}
