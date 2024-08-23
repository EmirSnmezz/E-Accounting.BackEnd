using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Accounting.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AppUserColumnAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserFirstAndLastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserFirstAndLastName",
                table: "AspNetUsers");
        }
    }
}
