using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class updateCastKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast",
                columns: new[] { "MovieId", "CastId", "Character" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast",
                columns: new[] { "MovieId", "CastId" });
        }
    }
}
