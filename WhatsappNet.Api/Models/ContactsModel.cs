using WhatsappNet.Api.Models.prueba;

namespace WhatsappNet.Api.Models
{
    public class ContactsModel
    {
        public int id { get; set; }
        public string wa_id { get; set; }
        public int? user_id { get; set; }
        public string? profile_name { get; set; }

        // // Clave foránea y navegación
        public int ValueModelId { get; set; }
        public ValueModel Values { get; set; }

        public List<MessageModel> Messages { get; set; } // Un contacto puede tener muchos mensajes

        public int StatusesModelId { get; set; }
        public StatusesModel Statuses { get; set; }


    }
}
