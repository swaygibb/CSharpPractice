using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Helpers
{
    public static class PagingHelper
    {
        public static PagingData SetPowerliftingPaging(IQueryable<PowerliftingResult> result, int page, int pageSize)
        {
            var totalItems = result.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var pagedResults = result
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return new PagingData(page, totalPages, pagedResults);
        }
    }
}
