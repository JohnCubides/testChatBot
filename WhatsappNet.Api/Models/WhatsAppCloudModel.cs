using OpenAI_API.Chat;
using System.Reflection.Metadata;
using WhatsappNet.Api.Models.prueba;

namespace WhatsappNet.Api.Models
{
    public class WhatsAppCloudModel
    {
        public List<Entry> Entry { get; set; }
    }
    public class Entry
    {
        public int? Id { get; set; }
        public List<Change>? Changes { get; set; }
    }
    public class Change
    {
        public Value? Value { get; set; }
        public string? Field { get; set; }
    }
    public class Value
    {
        public List<Contacts>? Contacts { get; set; }
        public List<Errors>? Errors { get; set; }   
        public string? Messaging_product { get; set; }
        public List<Message>? Messages { get; set; }
        public Metadata? Metadata { get; set; }
        public List<Statuses>? Statuses { get; set; }
    }
    public class Statuses
    {
        public string Biz_opaque_callback_data { get; set; }
        public Conversation Conversation { get; set; }
        public int? Id { get; set; }
        public Pricing? Pricing { get; set; }
        public string? recipient_id { get; set; }
        public string? Status { get; set; }
        public string? Timestamp { get; set; }
    }
    public class Pricing
    {
        public string Category { get; set; }
        public string Authentication { get; set; }
        public string Authentication_international { get; set; }
        public string Marketing { get; set; }
        public string Utility { get; set; }
        public string Service { get; set; }
        public string Referral_conversion { get; set; }
        public string Pricing_model { get; set; }
    }
    public class Conversation
    {
        public int? Id { get; set; }
        public Origin? Origin { get; set; }
    }
    public class Origin
    {
        public string Type { get; set; }
        public string Authentication { get; set; }
        public string Marketing { get; set; }
        public string Utility { get; set; }
        public string Service { get; set; }
        public string Referral_conversion { get; set; }
        public string Expiration_timestamp { get; set; }
    }

    public class Metadata
    {
        public string Display_phone_number { get; set; }
        public int Phone_number_id { get; set; }
    }
    public class Contacts
    {
        public string Wa_id { get; set; }
        public int? User_id { get; set; }
        public Profile? Profile { get; set; }
    }
    public class Errors
    {
        public int? Code { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public Error_data Error_data {  get; set; }

    }
     public class Message
     {
        public Audio? Audio { get; set; }
        public Context Context { get; set; }
        public Document Document { get; set; }
        public string? From { get; set; }
        public string? Id { get; set; }
        public Identity Identity { get; set; }
        public Image Image { get; set; }
        public Interactive? Interactive { get; set; }
        public Order? Order { get; set; }
        public Referral? Referral { get; set; }
        public Sticker? Sticker { get; set; }
        public System? System { get; set; }
        public Text? Text { get; set; }
        public string? Timestamp { get; set; }
        public string? Type { get; set; }
        public Video? Video { get; set; }

     }
    public class Video
    {
        public string? Caption { get; set; }
        public string? Filename { get; set; }
        public string? Sha256 { get; set; }
        public int? Id { get; set; }
        public string? Mime_type { get; set; }
    }
    public class System
    {
        public string? Body { get; set; }
        public string? Identity { get; set; }
        public int? New_wa_id { get; set; }
        public int? Wa_id { get; set; }
        public string? Type { get; set; }
        public string? Customer { get; set; }
    }
    public class Sticker
    {
        public string Mime_type { get; set; }
        public string Sha256 { get; set; }
        public int Id { get; set; }
        public bool Animated { get; set; }
    }
    public class Referral
    {
        public string? Source_url { get; set; }
        public string? Source_type { get; set; }
        public string? Source_id { get; set; }
        public string? Headline { get; set; }
        public string? Body { get; set; }
        public string? Media_type { get; set; }
        public string? Image_url { get; set; }
        public string? Video_url { get; set; }
        public string? Thumbnail_url { get; set; }
        public string? Ctwa_clid { get; set; }
    }
    public class Order
    {
        public int? Catalog_id { get; set; }
        public string? Text { get; set; }
        public List<ProductItem>? Product_items { get; set; }
    }
    public class ProductItem
    {
        public int? Product_retailer_id { get; set; }
        public string? Quantity { get; set; }
        public string? Item_price { get; set; }
        public string? Currency { get; set; }
    }
    public class Image
    {
        public string? Caption { get; set; }
        public string? Sha256 { get; set; }
        public int? Id { get; set; }
        public string? Mime_type { get; set; }
    }
     public class Interactive
     {
            public Type? Type { get; set; }
     }
    public class Type
    {
        public Button Button { get; set; }
        public ButtonReply Button_reply { get; set; }
        public ListReply List_reply { get; set; }
    }
        public class Button
        {
            public string? Payload { get; set; }
            public string? Text { get; set; }
        }
        public class ButtonReply
        {
            public string? Id { get; set; }
            public string? Title { get; set; }
        }
         public class ListReply
         {
                public string? Id { get; set; }
                public string? Title { get; set; }
                public string? Description { get; set; }
         }

        public class Text
        {
            public string? Body { get; set; }
        }
        public class Profile
        {
            public string Name { get; set; }
        }
    public class Error_data
    {
        public string details { get; set; }
    }
    public class Audio
    {
        public int Id { get; set; }
        public string Mime_type { get; set; }
    }
    public class Context
    {
        public bool? Forwarded { get; set; }
        public bool? Frequently_forwarded { get; set; }
        public string? From { get; set; }
        public int? Id { get; set; }
        public Referred_product Referred_product { get; set; }
    }
    public class Referred_product
    {
        public int Catalog_id { get; set; } 
        public int Product_retailer_id { get; set; } 

    }
    public class Document
    {
        public string? Caption { get; set; }
        public string? Filename { get; set; }
        public string? Sha256 { get; set; }
        public string? Mime_type { get; set; }
        public int? Id { get; set; }
    }
    public class Identity
    {
        public string? Acknowledged { get; set; }
        public string? Created_timestamp { get; set; }
        public string? Hash { get; set; }

    }


}
