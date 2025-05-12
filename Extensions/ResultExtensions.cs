namespace CSharpPractice.Extensions
{
    public static class ResultExtensions
    {
        public static string ToSlug(this string name)
        {
            return name.ToLower().Replace(" ", "-");
        }
    }
}
