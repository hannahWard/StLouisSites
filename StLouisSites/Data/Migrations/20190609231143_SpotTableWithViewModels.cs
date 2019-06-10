using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisSites.Data.Migrations
{
    public partial class SpotTableWithViewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Spots",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Spots");
        }
    }
}
