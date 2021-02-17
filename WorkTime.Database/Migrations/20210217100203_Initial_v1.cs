using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkTime.Database.Migrations
{
    public partial class Initial_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeFrames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WorkDayId = table.Column<int>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    LastCheck = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeFrames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeFrames_Days_WorkDayId",
                        column: x => x.WorkDayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeFrames_WorkDayId",
                table: "TimeFrames",
                column: "WorkDayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeFrames");

            migrationBuilder.DropTable(
                name: "Days");
        }
    }
}
