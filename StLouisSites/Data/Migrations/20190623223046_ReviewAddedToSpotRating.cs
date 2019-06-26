using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisSites.Data.Migrations
{
    public partial class ReviewAddedToSpotRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "SpotRatings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Review",
                table: "SpotRatings");
        }
    }
}
