using System.ComponentModel.DataAnnotations.Schema;

public class PowerliftingResult
{
    public int Id { get; set; }

    public required int MeetID { get; set; }

    [ForeignKey("MeetID")]
    public Meet? Meet { get; set; }

    public required string Name { get; set; }
    public required string Sex { get; set; }
    public required string Equipment { get; set; }
    public required int? Age { get; set; }
    public required string? Division { get; set; }

    public decimal? BodyweightKg { get; set; }
    public decimal? WeightClassKg { get; set; }

    public decimal? Squat4Kg { get; set; }
    public decimal? BestSquatKg { get; set; }

    public decimal? Bench4Kg { get; set; }
    public decimal? BestBenchKg { get; set; }

    public decimal? Deadlift4Kg { get; set; }
    public decimal? BestDeadliftKg { get; set; }

    public decimal? TotalKg { get; set; }
    public int? Place { get; set; }
    public decimal? Wilks { get; set; }

    [NotMapped]
    public string LifterRating => Wilks switch
    {
        null => "Unrated",
        < 200 => "Beginner",
        >= 200 and < 300 => "Novice",
        >= 300 and < 400 => "Intermediate",
        >= 400 and < 500 => "Advanced",
        >= 500 => "Elite"
    };

    public static Func<IQueryable<PowerliftingResult>, IQueryable<PowerliftingResult>> Recent =
        query => query.OrderByDescending(p => p.Id)
        .Take(20);
}
