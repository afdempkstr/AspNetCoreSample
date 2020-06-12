using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreSample.Migrations
{
    public partial class AddedSpecialCaseToCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpecialCase",
                table: "Candidates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialCase",
                table: "Candidates");
        }
    }
}
