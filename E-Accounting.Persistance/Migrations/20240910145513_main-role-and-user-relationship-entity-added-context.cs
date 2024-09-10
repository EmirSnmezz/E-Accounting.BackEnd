using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Accounting.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mainroleanduserrelationshipentityaddedcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAndCompanyRelationships_Users_AppUserId",
                table: "UserAndCompanyRelationships");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "UserAndCompanyRelationships");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "UserAndCompanyRelationships",
                newName: "MasterUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAndCompanyRelationships_AppUserId",
                table: "UserAndCompanyRelationships",
                newName: "IX_UserAndCompanyRelationships_MasterUserId");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "UserAndCompanyRelationships",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MainRoleAndUserRelationShips",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MainRoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainRoleAndUserRelationShips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainRoleAndUserRelationShips_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MainRoleAndUserRelationShips_MainRoles_MainRoleId",
                        column: x => x.MainRoleId,
                        principalTable: "MainRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MainRoleAndUserRelationShips_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAndCompanyRelationships_CompanyId",
                table: "UserAndCompanyRelationships",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MainRoleAndUserRelationShips_CompanyId",
                table: "MainRoleAndUserRelationShips",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MainRoleAndUserRelationShips_MainRoleId",
                table: "MainRoleAndUserRelationShips",
                column: "MainRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MainRoleAndUserRelationShips_UserId",
                table: "MainRoleAndUserRelationShips",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAndCompanyRelationships_Companies_CompanyId",
                table: "UserAndCompanyRelationships",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAndCompanyRelationships_Users_MasterUserId",
                table: "UserAndCompanyRelationships",
                column: "MasterUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAndCompanyRelationships_Companies_CompanyId",
                table: "UserAndCompanyRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAndCompanyRelationships_Users_MasterUserId",
                table: "UserAndCompanyRelationships");

            migrationBuilder.DropTable(
                name: "MainRoleAndUserRelationShips");

            migrationBuilder.DropIndex(
                name: "IX_UserAndCompanyRelationships_CompanyId",
                table: "UserAndCompanyRelationships");

            migrationBuilder.RenameColumn(
                name: "MasterUserId",
                table: "UserAndCompanyRelationships",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAndCompanyRelationships_MasterUserId",
                table: "UserAndCompanyRelationships",
                newName: "IX_UserAndCompanyRelationships_AppUserId");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "UserAndCompanyRelationships",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "UserAndCompanyRelationships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAndCompanyRelationships_Users_AppUserId",
                table: "UserAndCompanyRelationships",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
