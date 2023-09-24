using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bsef19a041_Project.Migrations
{
    public partial class oneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ProductsUser");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //    migrationBuilder.DropForeignKey(
            //        name: "FK_Product_users_UsersId",
            //        table: "Product");

            //    migrationBuilder.DropIndex(
            //        name: "IX_Product_UsersId",
            //        table: "Product");

            //    migrationBuilder.DropColumn(
            //        name: "UsersId",
            //        table: "Product");

            //    migrationBuilder.CreateTable(
            //        name: "ProductsUser",
            //        columns: table => new
            //        {
            //            ListOfUsersId = table.Column<int>(type: "int", nullable: false),
            //            ProductListId = table.Column<int>(type: "int", nullable: false)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_ProductsUser", x => new { x.ListOfUsersId, x.ProductListId });
            //            table.ForeignKey(
            //                name: "FK_ProductsUser_Product_ProductListId",
            //                column: x => x.ProductListId,
            //                principalTable: "Product",
            //                principalColumn: "Id",
            //                onDelete: ReferentialAction.Cascade);
            //            table.ForeignKey(
            //                name: "FK_ProductsUser_users_ListOfUsersId",
            //                column: x => x.ListOfUsersId,
            //                principalTable: "users",
            //                principalColumn: "Id",
            //                onDelete: ReferentialAction.Cascade);
            //        });

            //    migrationBuilder.CreateIndex(
            //        name: "IX_ProductsUser_ProductListId",
            //        table: "ProductsUser",
            //        column: "ProductListId");
        }
    }
    }
