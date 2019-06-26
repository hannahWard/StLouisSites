using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisSites.Data.Migrations
{
    public partial class AddedAddressToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Spots",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Spots",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Spots");

            migrationBuilder.DropColumn(
                name: "County",
                table: "Spots");
        }
    }
}
