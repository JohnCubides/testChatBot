using WhatsappNet.Api.Models.prueba;

namespace WhatsappNet.Api.Models
{
    public class ContactsModel
    {
        public int id { get; set; }
        public int wa_id { get; set; }
        public int user_id { get; set; }
        public int profile_name { get; set; }

        // // Clave foránea y navegación
        public int ValueModelId { get; set; }
        public ValueModel Values { get; set; }

        public int MessagesModelId { get; set; }
        public MessageModel Message { get; set; }

        public int StatusesModelId { get; set; }
        public StatusesModel Statuses { get; set; }


    }
}
