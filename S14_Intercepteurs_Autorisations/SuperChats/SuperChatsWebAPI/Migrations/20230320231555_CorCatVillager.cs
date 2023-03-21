using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperChatsWebAPI.Migrations
{
    public partial class CorCatVillager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdVillager",
                table: "Cat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdVillager",
                table: "Cat",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
