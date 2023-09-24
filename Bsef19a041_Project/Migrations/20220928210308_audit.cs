using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bsef19a041_Project.Migrations
{
    public partial class audit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "users",
                newName: "LastModifiedUserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "users",
                newName: "LastModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "users",
                newName: "CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "users",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Product",
                newName: "LastModifiedUserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Product",
                newName: "LastModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Product",
                newName: "CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Product",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "AdminTable",
                newName: "LastModifiedUserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "AdminTable",
                newName: "LastModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "AdminTable",
                newName: "CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "AdminTable",
                newName: "CreatedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifiedUserId",
                table: "users",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "LastModifiedDate",
                table: "users",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "users",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserId",
                table: "Product",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "LastModifiedDate",
                table: "Product",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Product",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "Product",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserId",
                table: "AdminTable",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "LastModifiedDate",
                table: "AdminTable",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "AdminTable",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "AdminTable",
                newName: "CreatedBy");
        }
    }
}
