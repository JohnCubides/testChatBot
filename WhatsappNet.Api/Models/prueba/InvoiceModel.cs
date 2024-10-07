namespace WhatsappNet.Api.Models.prueba
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public string NumeroFactura { get; set; }
        public int ClientId { get; set; }

        public virtual ClientModel ClientModel { get; set; }
    }
}
