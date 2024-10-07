using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WhatsappNet.Api.Migrations
{
    /// <inheritdoc />
    public partial class PruebaModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    error_data_details = table.Column<string>(type: "text", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false),
                    model_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    contact_id = table.Column<int>(type: "integer", nullable: false),
                    messaging_product = table.Column<string>(type: "text", nullable: false),
                    message_id = table.Column<int>(type: "integer", nullable: false),
                    metadata_display_phone_number = table.Column<string>(type: "text", nullable: false),
                    metadata_phone_number_id = table.Column<string>(type: "text", nullable: false),
                    statuses_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    biz_opaque_callback_data = table.Column<string>(type: "text", nullable: false),
                    conversation_id = table.Column<int>(type: "integer", nullable: false),
                    conversation_origin_type = table.Column<string>(type: "text", nullable: false),
                    conversation_origin_authentication = table.Column<string>(type: "text", nullable: false),
                    conversation_origin_marketing = table.Column<string>(type: "text", nullable: false),
                    conversation_origin_utility = table.Column<string>(type: "text", nullable: false),
                    conversation_origin_service = table.Column<string>(type: "text", nullable: false),
                    conversation_origin_referral_conversion = table.Column<string>(type: "text", nullable: false),
                    conversation_origin_expiration_timestamp = table.Column<string>(type: "text", nullable: false),
                    meta_id = table.Column<int>(type: "integer", nullable: false),
                    pricing_category = table.Column<string>(type: "text", nullable: false),
                    pricing_authentication = table.Column<string>(type: "text", nullable: false),
                    pricing_authentication_international = table.Column<string>(type: "text", nullable: false),
                    pricing_marketing = table.Column<string>(type: "text", nullable: false),
                    pricing_utility = table.Column<string>(type: "text", nullable: false),
                    pricing_service = table.Column<string>(type: "text", nullable: false),
                    pricing_referral_conversion = table.Column<string>(type: "text", nullable: false),
                    pricing_pricing_model = table.Column<string>(type: "text", nullable: false),
                    ValueModelId = table.Column<int>(type: "integer", nullable: false),
                    ContactsModelId = table.Column<int>(type: "integer", nullable: false),
                    MessagesModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Statuses_Values_ValueModelId",
                        column: x => x.ValueModelId,
                        principalTable: "Values",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    wa_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    profile_name = table.Column<int>(type: "integer", nullable: false),
                    ValueModelId = table.Column<int>(type: "integer", nullable: false),
                    MessagesModelId = table.Column<int>(type: "integer", nullable: false),
                    StatusesModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contacts_Statuses_StatusesModelId",
                        column: x => x.StatusesModelId,
                        principalTable: "Statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_Values_ValueModelId",
                        column: x => x.ValueModelId,
                        principalTable: "Values",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    audio_id = table.Column<int>(type: "integer", nullable: false),
                    audio_mime_type = table.Column<string>(type: "text", nullable: false),
                    button_payload = table.Column<string>(type: "text", nullable: true),
                    button_text = table.Column<string>(type: "text", nullable: false),
                    context_forwarded = table.Column<string>(type: "text", nullable: false),
                    context_frequently_forwarded = table.Column<string>(type: "text", nullable: false),
                    context_from = table.Column<string>(type: "text", nullable: false),
                    context_id = table.Column<int>(type: "integer", nullable: false),
                    context_referred_product_catalog_id = table.Column<int>(type: "integer", nullable: false),
                    context_referred_product_product_retailer_id = table.Column<int>(type: "integer", nullable: false),
                    document_caption = table.Column<string>(type: "text", nullable: false),
                    document_filename = table.Column<string>(type: "text", nullable: false),
                    document_sha256 = table.Column<string>(type: "text", nullable: false),
                    document_mime_type = table.Column<string>(type: "text", nullable: false),
                    document_id = table.Column<int>(type: "integer", nullable: false),
                    from = table.Column<string>(type: "text", nullable: false),
                    id_meta = table.Column<int>(type: "integer", nullable: false),
                    identity_acknowledged = table.Column<string>(type: "text", nullable: false),
                    identity_created_timestamp = table.Column<string>(type: "text", nullable: false),
                    identity_hash = table.Column<string>(type: "text", nullable: false),
                    image_caption = table.Column<string>(type: "text", nullable: false),
                    image_sha256 = table.Column<string>(type: "text", nullable: false),
                    image_id = table.Column<int>(type: "integer", nullable: false),
                    image_mime_type = table.Column<string>(type: "text", nullable: false),
                    interactive_type_button_reply_id = table.Column<int>(type: "integer", nullable: false),
                    interactive_type_button_reply_title = table.Column<string>(type: "text", nullable: false),
                    interactive_type_list_reply_id = table.Column<int>(type: "integer", nullable: false),
                    interactive_type_list_reply_title = table.Column<string>(type: "text", nullable: false),
                    interactive_type_list_reply_description = table.Column<string>(type: "text", nullable: false),
                    order_catalog_id = table.Column<int>(type: "integer", nullable: false),
                    order_text = table.Column<string>(type: "text", nullable: false),
                    referral_source_url = table.Column<string>(type: "text", nullable: false),
                    referral_source_type = table.Column<string>(type: "text", nullable: false),
                    referral_source_id = table.Column<int>(type: "integer", nullable: false),
                    referral_headline = table.Column<string>(type: "text", nullable: false),
                    referral_body = table.Column<string>(type: "text", nullable: false),
                    referral_media_type = table.Column<string>(type: "text", nullable: false),
                    referral_image_url = table.Column<string>(type: "text", nullable: false),
                    referral_video_url = table.Column<string>(type: "text", nullable: false),
                    referral_thumbnail_url = table.Column<string>(type: "text", nullable: false),
                    referral_ctwa_clid = table.Column<string>(type: "text", nullable: false),
                    sticker_mime_type = table.Column<string>(type: "text", nullable: false),
                    sticker_sha256 = table.Column<string>(type: "text", nullable: false),
                    sticker_id = table.Column<int>(type: "integer", nullable: false),
                    sticker_animated = table.Column<string>(type: "text", nullable: false),
                    system_body = table.Column<string>(type: "text", nullable: false),
                    system_identity = table.Column<string>(type: "text", nullable: false),
                    system_new_wa_id = table.Column<int>(type: "integer", nullable: false),
                    system_wa_id = table.Column<int>(type: "integer", nullable: false),
                    system_type = table.Column<string>(type: "text", nullable: false),
                    system_customer = table.Column<string>(type: "text", nullable: false),
                    text_body = table.Column<string>(type: "text", nullable: false),
                    timestamp = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    video_caption = table.Column<string>(type: "text", nullable: false),
                    video_filename = table.Column<string>(type: "text", nullable: false),
                    video_sha256 = table.Column<string>(type: "text", nullable: false),
                    video_id = table.Column<int>(type: "integer", nullable: false),
                    video_mime_type = table.Column<string>(type: "text", nullable: false),
                    ValueModelId = table.Column<int>(type: "integer", nullable: false),
                    ContactsModelId = table.Column<int>(type: "integer", nullable: false),
                    StatusesModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_Messages_Contacts_ContactsModelId",
                        column: x => x.ContactsModelId,
                        principalTable: "Contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Statuses_StatusesModelId",
                        column: x => x.StatusesModelId,
                        principalTable: "Statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Values_ValueModelId",
                        column: x => x.ValueModelId,
                        principalTable: "Values",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_StatusesModelId",
                table: "Contacts",
                column: "StatusesModelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ValueModelId",
                table: "Contacts",
                column: "ValueModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ContactsModelId",
                table: "Messages",
                column: "ContactsModelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_StatusesModelId",
                table: "Messages",
                column: "StatusesModelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ValueModelId",
                table: "Messages",
                column: "ValueModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_ValueModelId",
                table: "Statuses",
                column: "ValueModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Errors");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Values");
        }
    }
}
