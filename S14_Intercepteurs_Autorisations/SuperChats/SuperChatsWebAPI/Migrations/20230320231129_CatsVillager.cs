using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperChatsWebAPI.Migrations
{
    public partial class CatsVillager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillagerID",
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
                name: "IX_Cat_VillagerID",
                table: "Cat",
                column: "VillagerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_Villager_VillagerID",
                table: "Cat",
                column: "VillagerID",
                principalTable: "Villager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_Villager_VillagerID",
                table: "Cat");

            migrationBuilder.DropIndex(
                name: "IX_Cat_VillagerID",
                table: "Cat");

            migrationBuilder.DropColumn(
                name: "VillagerID",
                table: "Cat");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "AspNetUsers");
        }
    }
}
