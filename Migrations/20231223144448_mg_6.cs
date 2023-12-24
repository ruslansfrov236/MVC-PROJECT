using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_15.Migrations
{
    public partial class mg_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceName",
                table: "Pricing");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PriceName",
                table: "Pricing",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
