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
                name: "PowerliftingResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyweightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeightClassKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Squat4Kg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BestSquatKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bench4Kg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BestBenchKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deadlift4Kg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BestDeadliftKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Place = table.Column<int>(type: "int", nullable: true),
                    Wilks = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerliftingResults", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PowerliftingResults");
        }
    }
}
