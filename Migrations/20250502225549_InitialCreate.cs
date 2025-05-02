using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpPractice.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeetID = table.Column<int>(type: "INTEGER", nullable: false),
                    MeetPath = table.Column<string>(type: "TEXT", nullable: true),
                    Federation = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MeetCountry = table.Column<string>(type: "TEXT", nullable: true),
                    MeetState = table.Column<string>(type: "TEXT", nullable: true),
                    MeetTown = table.Column<string>(type: "TEXT", nullable: true),
                    MeetName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meets", x => x.Id);
                    table.UniqueConstraint("AK_Meets_MeetID", x => x.MeetID);
                });

            migrationBuilder.CreateTable(
                name: "PowerliftingResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeetID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: false),
                    Equipment = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: true),
                    Division = table.Column<string>(type: "TEXT", nullable: true),
                    BodyweightKg = table.Column<decimal>(type: "TEXT", nullable: true),
                    WeightClassKg = table.Column<decimal>(type: "TEXT", nullable: true),
                    Squat4Kg = table.Column<decimal>(type: "TEXT", nullable: true),
                    BestSquatKg = table.Column<decimal>(type: "TEXT", nullable: true),
                    Bench4Kg = table.Column<decimal>(type: "TEXT", nullable: true),
                    BestBenchKg = table.Column<decimal>(type: "TEXT", nullable: true),
                    Deadlift4Kg = table.Column<decimal>(type: "TEXT", nullable: true),
                    BestDeadliftKg = table.Column<decimal>(type: "TEXT", nullable: true),
                    TotalKg = table.Column<decimal>(type: "TEXT", nullable: true),
                    Place = table.Column<int>(type: "INTEGER", nullable: true),
                    Wilks = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerliftingResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerliftingResults_Meets_MeetID",
                        column: x => x.MeetID,
                        principalTable: "Meets",
                        principalColumn: "MeetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meets_MeetID",
                table: "Meets",
                column: "MeetID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PowerliftingResults_MeetID",
                table: "PowerliftingResults",
                column: "MeetID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PowerliftingResults");

            migrationBuilder.DropTable(
                name: "Meets");
        }
    }
}
