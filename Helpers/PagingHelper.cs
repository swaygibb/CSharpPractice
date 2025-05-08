using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CSharpPractice.Helpers
{
    public static class PagingHelper
    {
        public static (int page, int totalPages, IQueryable<PowerliftingResult> pagedResults) SetPowerliftingPaging(IQueryable<PowerliftingResult> result, int page, int pageSize)
        {
            var totalItems = result.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var pagedResults = result
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return (page, totalPages, pagedResults);
        }
    }
}
