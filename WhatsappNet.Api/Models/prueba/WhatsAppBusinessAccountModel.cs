namespace WhatsappNet.Api.Models.prueba
{
    public class WhatsAppBusinessAccountModel
    {
        public int Id { get; set; }
        public string DisplayPhoneNumber { get; set; }
        public string PhoneNumberId { get; set; }


        // Relaciones
        public List<ContactModel> Contacts { get; set; }
        public List<MessageModel> MessagesModel { get; set; }

    }
}
