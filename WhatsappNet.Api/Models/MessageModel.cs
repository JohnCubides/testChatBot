namespace WhatsappNet.Api.Models
{
    public class MessageModel
    {
        public int id { get; set; }
        public int audio_id { get; set; }
        public string audio_mime_type { get; set; }
        public string? button_payload { get; set; }
        public string button_text { get; set; }
        public string context_forwarded { get; set; }
        public string context_frequently_forwarded { get; set; }
        public string context_from { get; set; }
        public int context_id { get; set; }
        public int context_referred_product_catalog_id { get; set; }
        public int context_referred_product_product_retailer_id { get; set; }
        public string document_caption { get; set; }
        public string document_filename { get; set; }
        public string document_sha256 { get; set; }
        public string document_mime_type { get; set; }
        public int document_id { get; set; }



        public string from { get; set; }
        public int id_meta { get; set; }
        public string identity_acknowledged { get; set; }
        public string identity_created_timestamp { get; set; }
        public string identity_hash { get; set; }
        public string image_caption { get; set; }
        public string image_sha256 { get; set; }
        public int image_id { get; set; }
        public string image_mime_type { get; set; }
        public int interactive_type_button_reply_id { get; set; }
        public string interactive_type_button_reply_title { get; set; }
        public int interactive_type_list_reply_id { get; set; }
        public string interactive_type_list_reply_title { get; set; }
        public string interactive_type_list_reply_description { get; set; }
        public int order_catalog_id { get; set; }
        public string order_text { get; set; }
        public string referral_source_url { get; set; }
        public string referral_source_type { get; set; }
        public int referral_source_id { get; set; }
        public string referral_headline { get; set; }
        public string referral_body { get; set; }
        public string referral_media_type { get; set; }
        public string referral_image_url { get; set; }
        public string referral_video_url { get; set; }
        public string referral_thumbnail_url { get; set; }
        public string referral_ctwa_clid { get; set; }
        public string sticker_mime_type { get; set; }
        public string sticker_sha256 { get; set; }
        public int sticker_id { get; set; }
        public string sticker_animated { get; set; }
        public string system_body { get; set; }
        public string system_identity { get; set; }
        public int system_new_wa_id { get; set; }
        public int system_wa_id { get; set; }
        public string system_type { get; set; }
        public string system_customer { get; set; }
        public string text_body { get; set; }
        public string timestamp { get; set; }
        public string type { get; set; }
        public string video_caption { get; set; }
        public string video_filename { get; set; }
        public string video_sha256 { get; set; }
        public int video_id { get; set; }
        public string video_mime_type { get; set; }


        // // Clave foránea y navegación
        public int ValueModelId { get; set; }
        public ValueModel Values { get; set; }

        public int ContactsModelId { get; set; }
        public ContactsModel Contacts { get; set; }

        public int StatusesModelId { get; set; }
        public StatusesModel Statuses { get; set; }

    }
}
