using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpPractice.Migrations
{
    /// <inheritdoc />
    public partial class FixDecimalColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "BestSquatKg",
                table: "PowerliftingResults",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "BestBenchKg",
                table: "PowerliftingResults",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            // Add other decimal fields here if needed
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BestSquatKg",
                table: "PowerliftingResults",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "BestBenchKg",
                table: "PowerliftingResults",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            // Reverse other decimal field changes here if needed
        }
    }

}
