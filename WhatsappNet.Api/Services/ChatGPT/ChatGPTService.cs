using Newtonsoft.Json;
using OpenAI_API;
using OpenAI_API.Chat;
using WhatsappNet.Api.Models;

namespace WhatsappNet.Api.Services.ChatGPT
{
    public class ChatGPTService : IChatGPTService
    {
        public async Task<string> Execute(string textUser)
        {
            try
            {
                string map = "";
                var openAiService = new OpenAIAPI(map);

                var chatRequest = new ChatRequest
                {
                    Model = "gpt-4o",
                    Messages = new List<ChatMessage>
                    {
                         new ChatMessage(ChatMessageRole.System, "Gracias"),
                        new ChatMessage(ChatMessageRole.User, textUser)
                    },
                    MaxTokens = 200
                };

                var chatResult = await openAiService.Chat.CreateChatCompletionAsync(chatRequest);

                if (chatResult != null && chatResult.Choices.Count > 0)
                    return chatResult.Choices[0].Message.Content;

                return "Lo siento, sucedio un problema, intentalo mas tarde.";
            }
            catch (Exception e)
            {
                return "Lo siento, sucedio un problema, intentalo mas tarde.";
            }
        }

    }
}
