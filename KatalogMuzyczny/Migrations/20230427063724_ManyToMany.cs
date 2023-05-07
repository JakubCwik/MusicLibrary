using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KatalogMuzyczny.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Users_UserId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_UserId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Suppliers");

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

            migrationBuilder.CreateTable(
                name: "SupplierUsers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierUsers", x => new { x.SupplierId, x.UserId });
                    table.ForeignKey(
                        name: "FK_SupplierUsers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SupplierUserSupplierId_SupplierUserUserId",
                table: "Users",
                columns: new[] { "SupplierUserSupplierId", "SupplierUserUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierUsers_UserId",
                table: "SupplierUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SupplierUsers_SupplierUserSupplierId_SupplierUserUserId",
                table: "Users",
                columns: new[] { "SupplierUserSupplierId", "SupplierUserUserId" },
                principalTable: "SupplierUsers",
                principalColumns: new[] { "SupplierId", "UserId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SupplierUsers_SupplierUserSupplierId_SupplierUserUserId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "SupplierUsers");

            migrationBuilder.DropIndex(
                name: "IX_Users_SupplierUserSupplierId_SupplierUserUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SupplierUserSupplierId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SupplierUserUserId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_UserId",
                table: "Suppliers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Users_UserId",
                table: "Suppliers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
