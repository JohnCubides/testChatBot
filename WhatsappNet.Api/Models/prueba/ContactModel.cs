namespace WhatsappNet.Api.Models.prueba
{
    public class ContactModel
    {
        public int IdContact { get; set; }
        public string WaId { get; set; }
        public string UserId { get; set; }
        public string ProfileName { get; set; }


        // Clave foránea
        public int WhatsAppBusinessAccountId { get; set; }
        public WhatsAppBusinessAccountModel WhatsAppBusinessAccount { get; set; }

        // Relaciones
        public List<MessageModel> MessagesModel { get; set; }
    }
}
