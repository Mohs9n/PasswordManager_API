using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class rerewriteroll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Vault_vaultId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Passwords_Vault_VaultId",
                table: "Passwords");

            migrationBuilder.DropTable(
                name: "Vault");

            migrationBuilder.DropIndex(
                name: "IX_Passwords_VaultId",
                table: "Passwords");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_vaultId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VaultId",
                table: "Passwords");

            migrationBuilder.DropColumn(
                name: "vaultId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Passwords",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Passwords",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_AppUserId",
                table: "Passwords",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passwords_AspNetUsers_AppUserId",
                table: "Passwords",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passwords_AspNetUsers_AppUserId",
                table: "Passwords");

            migrationBuilder.DropIndex(
                name: "IX_Passwords_AppUserId",
                table: "Passwords");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Passwords");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Passwords");

            migrationBuilder.AddColumn<int>(
                name: "VaultId",
                table: "Passwords",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "vaultId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Vault",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vault", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_VaultId",
                table: "Passwords",
                column: "VaultId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_vaultId",
                table: "AspNetUsers",
                column: "vaultId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Vault_vaultId",
                table: "AspNetUsers",
                column: "vaultId",
                principalTable: "Vault",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passwords_Vault_VaultId",
                table: "Passwords",
                column: "VaultId",
                principalTable: "Vault",
                principalColumn: "Id");
        }
    }
}
