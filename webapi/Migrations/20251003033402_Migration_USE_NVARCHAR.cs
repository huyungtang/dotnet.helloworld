using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class Migration_USE_NVARCHAR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "user",
                type: "NVARCHAR(90)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(90)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "user",
                type: "VARCHAR(90)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(90)");
        }
    }
}
