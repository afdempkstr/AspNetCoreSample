using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreSample.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Specialisations_SpecialisationId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Candidates");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialisationId",
                table: "Candidates",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Specialisations",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "A C# back end Developer...", "C# Developer" });

            migrationBuilder.InsertData(
                table: "Specialisations",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "A Java back end Developer...", "Java Developer" });

            migrationBuilder.InsertData(
                table: "Specialisations",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "A developer who can write everything", "Full-Stack Developer" });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "Description", "FirstName", "ImageThumbnailUrl", "ImageUrl", "IsAvailable", "IsPopularCandidate", "LastName", "Rating", "SpecialisationId" },
                values: new object[,]
                {
                    { 1, "Lorem Ipsum", "Nick", "https://randomuser.me/api/portraits/lego/5.jpg", null, true, true, "Papadopoulos", 15.95m, 1 },
                    { 2, "Lorem Ipsum", "John", "https://randomuser.me/api/portraits/lego/3.jpg", null, true, false, "Katinas", 16.34m, 2 },
                    { 3, "Lorem Ipsum", "George", "https://randomuser.me/api/portraits/lego/8.jpg", null, true, false, "Floyd", 17.12m, 3 },
                    { 4, "Black Lives Matter", "Breonna", "https://randomuser.me/api/portraits/lego/2.jpg", null, true, true, "Taylor", 18.44m, 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Specialisations_SpecialisationId",
                table: "Candidates",
                column: "SpecialisationId",
                principalTable: "Specialisations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Specialisations_SpecialisationId",
                table: "Candidates");

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specialisations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specialisations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specialisations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "SpecialisationId",
                table: "Candidates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Specialisations_SpecialisationId",
                table: "Candidates",
                column: "SpecialisationId",
                principalTable: "Specialisations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
