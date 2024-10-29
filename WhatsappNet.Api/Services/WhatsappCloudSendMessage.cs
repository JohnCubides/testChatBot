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
                string accessToken = "Bearer EAF5OwUZABAzUBOzZA52XZBzhReST1CReDwJeOLup2ZBlZBBF8tOuOb02xcAaRjsjaovOTjMZBNLaSXeehMQWO3VAiktZCaF2tXJICTAKWiSKi6qdCMeXhwbUYvItlT0UZAM6TbukwJy7H28HvibtQSPxiSAQBtTwXPWIZBj5MZCTIm43tlA93XEvlJ2bHAOIIoIICay2zvuZAE79g0XZCMaxGkqZBgk0TqAZDZD";
                string uri = $"{domain}/{versionApi}/{phoneNumberId}/{path}";

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                client.DefaultRequestHeaders.Add("Authorization", accessToken);

                var response = await client.PostAsync(uri, content);

                Task<string> contenido = response.Content.ReadAsStringAsync();
                String result = contenido.Result;

                if (response.IsSuccessStatusCode) {
                    return true;
                }

                return false;
            }
        }
    }
}
