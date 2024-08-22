namespace WhatsappNet.Api.Services
{
    public interface IWhatsappCloudSendMessage
    {
        Task<bool> Execute(object model); 
    }
}
