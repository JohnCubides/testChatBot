namespace WhatsappNet.Api.Models
{
    public class ErrorModel
    {
        public int id { get; set; }
        public int code { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string error_data_details { get; set; }
        public string model { get; set; }
        public int model_id { get; set; }
    }
}
