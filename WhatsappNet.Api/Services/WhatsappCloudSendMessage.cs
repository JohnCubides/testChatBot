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
                string accessToken = "Bearer EAF5OwUZABAzUBOyY8AEgFRKHHSpkZB1aSHxbexTZBp6BRtZAxZCw4P7uB6dydakAv6bTKnZAwkpBBMrDzp5lEo0nBTkskrhxhGrMGlIBp4kiTwauWp8E4tvQqPyAarDdCO6YGmIiHkA37k88PeQMKXZAlwa8vBrLZCDmA7nByRGGgDVTQZBIsN7TZBRpz9ajsKyZCgcVJyR2fXXi1O9A8HAEwZDZD";
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
