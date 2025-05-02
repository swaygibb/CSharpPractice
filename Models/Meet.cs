public class Meet
{
    public int Id { get; set; }
    public required int MeetID { get; set; }
    public string? MeetPath { get; set; }
    public string? Federation { get; set; }
    public DateTime? Date { get; set; }
    public string? MeetCountry { get; set; }
    public string? MeetState { get; set; }
    public string? MeetTown { get; set; }
    public string? MeetName { get; set; }

    public List<PowerliftingResult>? Results { get; set; }
}
