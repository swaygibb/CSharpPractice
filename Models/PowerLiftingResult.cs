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

    [NotMapped]
    public string Commentary => this switch
    {
        { Wilks: >= 500 } => $"{Name} delivered an elite performance with a Wilks of {Wilks}!",

        { Wilks: >= 400 } when Sex == "F" => $"{Name} is one of the strongest women in the meet.",
        { Wilks: >= 400 } => $"{Name} is putting up serious numbers!",

        { Age: <= 18 } when TotalKg >= 400 => $"{Name} is a teen phenom lifting {TotalKg}kg total!",
        { Age: >= 50 } when TotalKg >= 500 => $"{Name} proves strength has no age limit.",

        { Equipment: "Raw" } when TotalKg >= 600 => $"{Name} shows raw power with a {TotalKg}kg total.",
        { Equipment: "Wraps" } when BestSquatKg >= 300 => $"{Name} is crushing squats with wraps!",

        { BestDeadliftKg: >= 300 } => $"{Name}'s deadlift is monstrous at {BestDeadliftKg}kg.",
        { BestBenchKg: >= 200 } => $"{Name}'s bench press is elite at {BestBenchKg}kg.",

        { BestSquatKg: >= 250 } when BodyweightKg < 75 =>
            $"{Name} squatted over 3x their bodyweight — unreal strength-to-weight ratio!",

        { TotalKg: null } => $"{Name} has not completed their total yet.",

        _ => $"{Name} gave a solid effort on the platform."
    };


    public static Func<IQueryable<PowerliftingResult>, IQueryable<PowerliftingResult>> Recent =
        query => query.OrderByDescending(p => p.Id)
        .Take(20);
}
