using CSharpPractice.Models;

namespace CSharpPractice.Helpers
{
    public class SearchHelper
    {
        public static IQueryable<PowerliftingResult> SearchQuery(IQueryable<PowerliftingResult> results, string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return results;

            var query = results.Where(r =>
                r.Name.Contains(searchString) ||
                (r.Division != null && r.Division.Contains(searchString)) ||
                (r.Meet != null && r.Meet.MeetName != null && r.Meet.MeetName.Contains(searchString)) ||
                (r.Meet != null && r.Meet.Federation != null && r.Meet.Federation.Contains(searchString)));

            return query;
        }

    }
}
