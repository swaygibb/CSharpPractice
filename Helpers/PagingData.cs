namespace Helpers
{
    public readonly struct PagingData
    {
        public int Page { get; }
        public int TotalPages { get; }
        public IQueryable<PowerliftingResult> Results { get; }

        public PagingData(int page, int totalPages, IQueryable<PowerliftingResult> results)
        {
            Page = page;
            TotalPages = totalPages;
            Results = results;
        }
    }
}
