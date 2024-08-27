namespace WhatsappNet.Api.Services.Gemini
{
    public interface IGeminiAPI
    {
        Task<string> Execute(object model);
    }
}
