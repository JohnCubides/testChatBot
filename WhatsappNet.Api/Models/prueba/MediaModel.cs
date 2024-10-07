namespace WhatsappNet.Api.Models.prueba
{
    public class MediaModel
    {
        public int IdMedia { get; set; }
        public string MediaType { get; set; }
        public string MimeType { get; set; }
        public string Sha256 { get; set; }
        public string FileName { get; set; }
        public string Caption { get; set; }


        // Clave foránea
        public int IdMessage { get; set; }
        public MessageModel MessagesModel { get; set; }
    }
}
