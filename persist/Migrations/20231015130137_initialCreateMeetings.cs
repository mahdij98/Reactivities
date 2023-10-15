using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace persist.Migrations
{
    /// <inheritdoc />
    public partial class initialCreateMeetings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Activities");

            migrationBuilder.CreateTable(
                name: "Meetinges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetinges", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meetinges");

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Activities",
                type: "TEXT",
                nullable: true);
        }
    }
}
