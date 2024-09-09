namespace WhatsappNet.Api.Services.ChatGPT
{
    public interface IChatGPTService
    {
        Task<string> Execute(string textUser);
    }
}
