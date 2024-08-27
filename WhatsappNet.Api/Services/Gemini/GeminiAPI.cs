using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace WhatsappNet.Api.Services.Gemini
{
    public class GeminiAPI : IGeminiAPI
    {
        public async Task<string> Execute(object model)
        {
            Task<string> result = Task.FromResult(string.Empty);
            HttpClient client = new HttpClient();
            Byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));

            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                string map = "AIzaSyCx84cuVmifqBCEBY2syh4H0VTLIsR4HHc";
                string domain = "https://generativelanguage.googleapis.com";
                string path = "/v1/models/gemini-pro:generateContent";
                string queryParams = $"key={map}";
                string uri = $"{domain}/{path}?{queryParams}";

                var response = await client.PostAsync(uri, content);
                result = response.Content.ReadAsStringAsync();
                
            }
            return await result;
        }
    }
}
