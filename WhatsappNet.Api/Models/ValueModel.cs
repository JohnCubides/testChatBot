using WhatsappNet.Api.Models.prueba;

namespace WhatsappNet.Api.Models
{
    public class ValueModel
    {
        public int id { get; set; }
        public int contact_id { get; set; }
        public string messaging_product { get; set; }
        public int message_id { get; set; }
        public string metadata_display_phone_number { get; set; }
        public string metadata_phone_number_id { get; set; }
        public int statuses_id { get; set; }

        // Relaciones
        public ICollection<ContactsModel> Contacts { get; set; }
        public ICollection<MessageModel> Messages { get; set; }
        public ICollection<StatusesModel> Statuses { get; set; }
    }
}
