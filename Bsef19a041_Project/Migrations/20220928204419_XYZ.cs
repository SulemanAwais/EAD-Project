using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bsef19a041_Project.Migrations
{
    public partial class XYZ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Product_users_UsersId",
            //    table: "Product");

            //migrationBuilder.DropIndex(
            //    name: "IX_Product_UsersId",
            //    table: "Product");

            //migrationBuilder.DropColumn(
            //    name: "UsersId",
            //    table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "UsersId",
            //    table: "Product",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Product_UsersId",
            //    table: "Product",
            //    column: "UsersId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Product_users_UsersId",
            //    table: "Product",
            //    column: "UsersId",
            //    principalTable: "users",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
