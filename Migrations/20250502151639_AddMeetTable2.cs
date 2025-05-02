using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpPractice.Migrations
{
    /// <inheritdoc />
    public partial class AddMeetTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetID = table.Column<int>(type: "int", nullable: false),
                    MeetPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Federation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeetCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetTown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meets");
        }
    }
}
