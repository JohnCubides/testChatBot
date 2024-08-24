using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace WhatsappNet.Api.Services
{
    public class WhatsappCloudSendMessage: IWhatsappCloudSendMessage
    {
        public async Task<bool> Execute( object model) {
            HttpClient client = new HttpClient();
            Byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));

            using (ByteArrayContent content = new ByteArrayContent(byteData)) {
                string domain = "https://graph.facebook.com";
                string phoneNumberId = "416983421494537";
                string versionApi = "v20.0";
                string path = "messages";
                string accessToken = "Bearer EAF5OwUZABAzUBO3kuck5rJWhRjFOfAGIZAXdnAvs7uSeC2OmOaZC5rEj9SIZBLol5z0ZBN3QEt04hwxZCJOHVNHR93Hov0vRIwxZAH8NzhBbzHkq4f5whHpmReZCntFKZB2e048Qh7gxbsoNzrBnCcOwnWXZCEAL5xpqZCy35TqlDs6cB8sbTimPzruStBYhSjVeSEFepp6do8WfYUOZAX0o893bttbr3VXU8DipwXgsePkZD";
                string uri = $"{domain}/{versionApi}/{phoneNumberId}/{path}";

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                client.DefaultRequestHeaders.Add("Authorization", accessToken);

                var response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode) {
                    return true;
                }

                return false;
            }
        }
    }
}
