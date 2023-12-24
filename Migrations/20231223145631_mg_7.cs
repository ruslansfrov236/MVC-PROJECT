using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_15.Migrations
{
    public partial class mg_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PricngName",
                table: "Pricing",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricngName",
                table: "Pricing");
        }
    }
}
