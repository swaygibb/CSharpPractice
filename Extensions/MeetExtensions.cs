using CSharpPractice.Models;

namespace CSharpPractice.Extensions
{
    public static class MeetExtensions
    {
        public static string FormatDate(this DateTime? date, string format = "MMMM dd, yyyy")
        {
            return date?.ToString(format) ?? "No Date";
        }
    }
}
