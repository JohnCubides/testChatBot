namespace WhatsappNet.Api.Models.prueba
{
    public class OrderModel
    {
        public int IdOrder { get; set; }
        public string CatalogId { get; set; }
        public string Text { get; set; }
        public string ProductRetailerId { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public string Currency { get; set; }

        // Clave foránea
        public int MessageId { get; set; }
        public Message MessagesModel { get; set; }
    }
}
