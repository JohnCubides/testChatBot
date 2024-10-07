namespace WhatsappNet.Api.Models
{
    public class PruebaModel
    {
       
        
        public class Product_items
        {
            public int id { get; set; } 
            public int product_retailer_id { get; set; }
            public string quantity { get; set; }
            public string item_price { get; set; }
            public string currency { get; set; }
        }
        public class Message_product_items
        {
            public int message_id { get; set; }
            public int product_items_id { get; set; }
        }
        
    }
}
