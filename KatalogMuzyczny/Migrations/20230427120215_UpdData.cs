using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KatalogMuzyczny.Migrations
{
    /// <inheritdoc />
    public partial class UpdData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SupplierUsers_SupplierUserSupplierId_SupplierUserUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SupplierUserSupplierId_SupplierUserUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SupplierUserSupplierId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SupplierUserUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SupplierUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierUserSupplierId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierUserUserId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SupplierUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SupplierUserSupplierId_SupplierUserUserId",
                table: "Users",
                columns: new[] { "SupplierUserSupplierId", "SupplierUserUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SupplierUsers_SupplierUserSupplierId_SupplierUserUserId",
                table: "Users",
                columns: new[] { "SupplierUserSupplierId", "SupplierUserUserId" },
                principalTable: "SupplierUsers",
                principalColumns: new[] { "SupplierId", "UserId" });
        }
    }
}
