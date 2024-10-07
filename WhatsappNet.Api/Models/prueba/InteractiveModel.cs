namespace WhatsappNet.Api.Models.prueba
{
    public class InteractiveModel
    {
        public int IdInteractive { get; set; }
        public string Type { get; set; }
        public string ButtonReplyId { get; set; }
        public string ButtonReplyTitle { get; set; }
        public string ListReplyId { get; set; }
        public string ListReplyTitle { get; set; }
        public string ListReplyDescription { get; set; }

        // Clave foránea
        public int MessageId { get; set; }
        public Message MessagesModel { get; set; }
    }
}
