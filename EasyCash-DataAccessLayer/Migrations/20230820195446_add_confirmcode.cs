using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCash_DataAccessLayer.Migrations
{
    public partial class add_confirmcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfirmedCod",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmedCod",
                table: "AspNetUsers");
        }
    }
}
