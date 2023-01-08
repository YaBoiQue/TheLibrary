using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidTireEstimates.Migrations
{
    public partial class CreatedServiceNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AddColumn<int>(
                name: "ServiceNumber",
                table: "Service",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropColumn(
                name: "ServiceNumber",
                table: "Service");
        }
    }
}
