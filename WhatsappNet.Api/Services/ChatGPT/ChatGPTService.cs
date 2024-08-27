using OpenAI_API;
using OpenAI_API.Completions;

namespace WhatsappNet.Api.Services.ChatGPT
{
    public class ChatGPTService : IChatGPTService
    {
        public async Task<string> Execute(string textUser)
        {
            try
            {
                string apiKey = "";
                var openAiService = new OpenAIAPI(apiKey);

                var completion = new CompletionRequest
                {
                    Prompt = textUser,
                    Model = "gpt-3.5-turbo",
                    NumChoicesPerPrompt = 1,
                    MaxTokens = 100
                };

                var result = await openAiService.Completions.CreateCompletionAsync(completion);

                if (result != null && result.Completions.Count > 0)
                    return result.Completions[0].Text;

                return "Lo siento, sucedio un problema, intentalo mas tarde.";
            }
            catch (Exception e)
            {
                return "Lo siento, sucedio un problema, intentalo mas tarde.";
            }
        }

    }
}
