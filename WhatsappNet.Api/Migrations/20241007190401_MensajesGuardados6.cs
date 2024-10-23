using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsappNet.Api.Migrations
{
    /// <inheritdoc />
    public partial class MensajesGuardados6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Messages_ContactsModelId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessagesModelId",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "profile_name",
                table: "Contacts",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ContactsModelId",
                table: "Messages",
                column: "ContactsModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Messages_ContactsModelId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "profile_name",
                table: "Contacts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MessagesModelId",
                table: "Contacts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ContactsModelId",
                table: "Messages",
                column: "ContactsModelId",
                unique: true);
        }
    }
}
