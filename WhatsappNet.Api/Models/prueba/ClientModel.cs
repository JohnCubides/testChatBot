namespace WhatsappNet.Api.Models
{
    public class ClientModel
    {
        public int Id { get; set; }        // Clave primaria
        public string Nombre { get; set; } // Nombre del cliente
        public string? Email { get; set; }  // Email del cliente

    }
}