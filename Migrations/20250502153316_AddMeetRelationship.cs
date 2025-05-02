using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpPractice.Migrations
{
    /// <inheritdoc />
    public partial class AddMeetRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MeetID",
                table: "PowerliftingResults",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Meets_MeetID",
                table: "Meets",
                column: "MeetID");

            migrationBuilder.CreateIndex(
                name: "IX_PowerliftingResults_MeetID",
                table: "PowerliftingResults",
                column: "MeetID");

            migrationBuilder.CreateIndex(
                name: "IX_Meets_MeetID",
                table: "Meets",
                column: "MeetID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PowerliftingResults_Meets_MeetID",
                table: "PowerliftingResults",
                column: "MeetID",
                principalTable: "Meets",
                principalColumn: "MeetID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PowerliftingResults_Meets_MeetID",
                table: "PowerliftingResults");

            migrationBuilder.DropIndex(
                name: "IX_PowerliftingResults_MeetID",
                table: "PowerliftingResults");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Meets_MeetID",
                table: "Meets");

            migrationBuilder.DropIndex(
                name: "IX_Meets_MeetID",
                table: "Meets");

            migrationBuilder.AlterColumn<string>(
                name: "MeetID",
                table: "PowerliftingResults",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
