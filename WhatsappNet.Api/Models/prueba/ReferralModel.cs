namespace WhatsappNet.Api.Models.prueba
{
    public class ReferralModel
    {
        public int IdReferral { get; set; }
        public string SourceUrl { get; set; }
        public string SourceType { get; set; }
        public string SourceId { get; set; }
        public string Headline { get; set; }
        public string Body { get; set; }
        public string MediaType { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string CtwaClid { get; set; }

        // Clave foránea
        public int MessageId { get; set; }
        public Message MessagesModel { get; set; }
    }
}
