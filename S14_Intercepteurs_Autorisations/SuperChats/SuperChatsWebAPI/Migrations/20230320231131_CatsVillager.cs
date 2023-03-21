using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperChatsWebAPI.Migrations
{
    public partial class CatsVillager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdVillager",
                table: "Cat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VillagerId",
                table: "Cat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_VillagerId",
                table: "Cat",
                column: "VillagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_Villager_VillagerId",
                table: "Cat",
                column: "VillagerId",
                principalTable: "Villager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_Villager_VillagerId",
                table: "Cat");

            migrationBuilder.DropIndex(
                name: "IX_Cat_VillagerId",
                table: "Cat");

            migrationBuilder.DropColumn(
                name: "IdVillager",
                table: "Cat");

            migrationBuilder.DropColumn(
                name: "VillagerId",
                table: "Cat");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "AspNetUsers");
        }
    }
}
