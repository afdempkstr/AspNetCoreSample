using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreSample.Migrations
{
    public partial class AddSelectedTeamCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SelectedTeamCandidates",
                columns: table => new
                {
                    SelectedTeamCandidateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(nullable: true),
                    SelectedTeamId = table.Column<string>(nullable: true),
                    OfferPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedTeamCandidates", x => x.SelectedTeamCandidateId);
                    table.ForeignKey(
                        name: "FK_SelectedTeamCandidates_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelectedTeamCandidates_CandidateId",
                table: "SelectedTeamCandidates",
                column: "CandidateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedTeamCandidates");
        }
    }
}
