namespace WhatsappNet.Api.Models
{
    public class StatusesModel
    {
        public int id { get; set; }
        public string biz_opaque_callback_data { get; set; }
        public int conversation_id { get; set; }
        public string conversation_origin_type { get; set; }
        public string conversation_origin_authentication { get; set; }
        public string conversation_origin_marketing { get; set; }
        public string conversation_origin_utility { get; set; }
        public string conversation_origin_service { get; set; }
        public string conversation_origin_referral_conversion { get; set; }
        public string conversation_origin_expiration_timestamp { get; set; }
        public int meta_id { get; set; }
        public string pricing_category { get; set; }
        public string pricing_authentication { get; set; }
        public string pricing_authentication_international { get; set; }
        public string pricing_marketing { get; set; }
        public string pricing_utility { get; set; }
        public string pricing_service { get; set; }
        public string pricing_referral_conversion { get; set; }
        public string pricing_pricing_model { get; set; }


        // Clave foránea y navegación
        public int ValueModelId { get; set; }
        public ValueModel Values { get; set; }

        public int ContactsModelId { get; set; }
        public ContactsModel Contacts { get; set; }

        public int MessagesModelId { get; set; }
        public MessageModel Message { get; set; }

    }
}
