using CSharpPractice.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<PowerliftingResult> PowerliftingResults { get; set; }

    public DbSet<Meet> Meets { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Meet>()
            .HasIndex(m => m.MeetID)
            .IsUnique();

        modelBuilder.Entity<PowerliftingResult>()
            .HasOne(pr => pr.Meet)
            .WithMany(m => m.Results)
            .HasForeignKey(pr => pr.MeetID)
            .HasPrincipalKey(m => m.MeetID);
    }
}
