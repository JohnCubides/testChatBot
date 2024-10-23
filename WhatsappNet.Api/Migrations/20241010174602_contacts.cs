using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsappNet.Api.Migrations
{
    /// <inheritdoc />
    public partial class Contacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "wa_id",
                table: "Contacts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "wa_id",
                table: "Contacts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
